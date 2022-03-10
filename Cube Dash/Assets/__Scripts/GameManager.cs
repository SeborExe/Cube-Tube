using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2f;

    public GameObject completeLevelUI;

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
            StartCoroutine(FindObjectOfType<CheckPoint>().CheckPointCoroutine(CheckPointsStats.GetActualCheckPoint()));
            FindObjectOfType<PlayerMovement>().speed = FindObjectOfType<PlayerMovement>().BasicSpeed;
        }
    }
}
