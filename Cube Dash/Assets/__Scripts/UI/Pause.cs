using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI; //Pause Panel
    public GameObject pauseBG; //Pause Panel background with buttons
    public GameObject pauseButton; //Button in main Canvans
    public GameObject CounterText; //Counter before resume game
    public GameObject MainCanvas; //MainCanvas

    public void Resume()
    {
        StartCoroutine(ResumeCoroutine());
    }

    IEnumerator ResumeCoroutine()
    {
        CounterText.SetActive(true);
        pauseBG.SetActive(false);

        for (int i = 3; i > 0; i--)
        {
            CounterText.GetComponent<Text>().text = i.ToString();

            for (int j = 0; j < 25; j++)
                yield return new WaitForEndOfFrame();
        }

        pauseBG.SetActive(true);
        CounterText.SetActive(false);

        pauseMenuUI.SetActive(false);
        MainCanvas.SetActive(true);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    public void PauseGame()
    {
        MainCanvas.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void PlayLevelAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CheckPointsStats.SetCurrentCheckPoint(0);
    }
}
