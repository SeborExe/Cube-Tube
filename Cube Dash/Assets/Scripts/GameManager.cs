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

        var money = FindObjectOfType<CrystalCounter>().ReachedCrystals() * 5 + (1000 / FindObjectOfType<InnerTimer>().time);
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
            if (FindObjectOfType<StopBlock>() != null)
            {
                if (FindObjectOfType<StopBlock>().speed != 0)
                    FindObjectOfType<StopBlock>().PlayerActive();
            }

            StartCoroutine(FindObjectOfType<CheckPoint>().CheckPointCoroutine(CheckPointsStats.GetActualCheckPoint())); 
        }
    }
}
