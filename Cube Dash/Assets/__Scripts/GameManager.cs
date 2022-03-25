using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public bool gameHasEnded = false;
    public float restartDelay = 2f;

    public GameObject playerPrefab;
    private float checkpoint;

    public GameObject completeLevelUI;

    private Material playerMat;
    private float playerSpeed;

    private void Awake()
    {
        S = this;
        
    }

    public void CompleteLevel()
    {
        //Aktywowaæ now¹ stronê koñcow¹
        completeLevelUI.SetActive(true);

        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        var money = FindObjectOfType<CrystalCounter>().ReachedCrystals() * 5 + ((1000 + (100 * levelNumber)) / FindObjectOfType<InnerTimer>().time);
        FindObjectOfType<LevelComplete>().MoneyText.text = "+" + money;
        PlayerPrefs.SetInt("money", money);
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Respawn", restartDelay);
        }
    }

    void Respawn()
    {
        if (CheckPointsStats.GetActualCheckPoint() == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        else
        {
            checkpoint = CheckPointsStats.GetActualCheckPoint();
            CheckPoint(checkpoint);
        }
    }

    private void CheckPoint(float pos)
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "Player")
            {
                Destroy(gameObj);
            }
        }

        if (FindObjectOfType<PlayerMovement>() == null)
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 2, pos), Quaternion.Euler(0, 0, 0));
            player.GetComponent<PlayerDeadMeshDestroy>().enabled = false;
            InitialPlayer();
            FindObjectOfType<Camera>().FindPlayer();

            player.GetComponent<PlayerDeadMeshDestroy>().enabled = true;
            FindObjectOfType<GameManager>().gameHasEnded = false;
        }
    }

    public void SavePlayerSettings(Material material, float speed)
    {
        playerMat = material;
        playerSpeed = speed;
        FindObjectOfType<PlayerMovement>().firstTime = false;
    }

    public void InitialPlayer()
    {
        var player = FindObjectOfType<PlayerMovement>();
        player.speed = playerSpeed;

        player.GetComponent<MeshRenderer>().material = playerMat;
    }
}
