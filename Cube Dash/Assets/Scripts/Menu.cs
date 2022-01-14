using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenuCanvas;

    [SerializeField]
    GameObject OptionsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CheckPointsStats.SetCurrentCheckPoint(0);
    }

    public void Options()
    {
        MainMenuCanvas.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void BackToMenuFromOptions()
    {
        MainMenuCanvas.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    public void GoToTubes()
    {
        SceneManager.LoadScene("TubesAndLevels");
    }

    public void Shop() => SceneManager.LoadScene("Shop");
}
