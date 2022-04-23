using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public bool gameHasEnded = false;
    public float restartDelay = 2f;

    private float checkpoint;

    public GameObject completeLevelUI;
    StopBlock stopBlock;

    private void Awake()
    {
        S = this;
    }

    private void Start()
    {
        stopBlock = FindObjectOfType<StopBlock>();
    }

    public void CompleteLevel()
    {
        //Aktywowaæ now¹ stronê koñcow¹
        completeLevelUI.SetActive(true);

        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        var money = FindObjectOfType<CrystalCounter>().ReachedCrystals() * 5 + ((1000 + (100 * levelNumber)) / FindObjectOfType<InnerTimer>().time);
        FindObjectOfType<LevelComplete>().MoneyText.text = "+" + money;
        PlayerPrefs.SetInt("money", money);

        if (LevelStats.GetHighestLevel() < (levelNumber + 1))
        {
            LevelStats.SetHighestLevel((levelNumber + 1));
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Respawn", restartDelay);
        }
    }

    public void OutOfMapEndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("OutOfMapRespawn", restartDelay);
        }
    }

    void Respawn()
    {
        if (stopBlock != null && stopBlock.PlayerIsOnBlock)
            stopBlock.PlayerActive();

        if (CheckPointsStats.GetActualCheckPoint() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else
        {
            checkpoint = CheckPointsStats.GetActualCheckPoint();
            SpawnManager.S.CheckPoint(checkpoint);
        }
    }

    void OutOfMapRespawn()
    {
        checkpoint = CheckPointsStats.GetActualCheckPoint();
        StartCoroutine(SpawnManager.S.CheckPointCoroutine(checkpoint));
    }
}
