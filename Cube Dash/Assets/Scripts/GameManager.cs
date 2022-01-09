using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2f;

    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
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
            StartCoroutine(FindObjectOfType<CheckPoint>().CheckPointCoroutine(CheckPointsStats.GetActualCheckPoint()));
    }
}
