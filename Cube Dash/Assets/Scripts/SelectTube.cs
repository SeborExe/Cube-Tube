using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectTube : MonoBehaviour
{

    public GameObject[] Tubes;
    public GameObject[] ClosedTubes;
    public Text[] RequiredStarts;

    public GameObject[] Levels;
    public GameObject[] Padlocks;
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        for (int i = 1; i <= Levels.Length; i++)
        {
            if (PlayerPrefs.GetInt(i + "Unlocked") == 1)
                Padlocks[i - 1].SetActive(false);
        }

        //Tubes
        if (LevelStats.GetAllStars() == 8)
        {
            ClosedTubes[0].SetActive(false);
        }

        //Required Stars
        for (int i = 1; i <= Tubes.Length; i++)
        {
            if (i == 1)
                RequiredStarts[0].text = LevelStats.GetAllStars() + "/8";
        }
    }

    public void SelectLevel1()
    {
        if (Padlocks[0].activeSelf == false)
            SceneManager.LoadScene("Level1");
    }

    public void SelectLevel2()
    {
        if (Padlocks[1].activeSelf == false)
            SceneManager.LoadScene("Level2");
    }

    public void SelectLevel3()
    {
        if (Padlocks[2].activeSelf == false)
            SceneManager.LoadScene("Level3");
    }

    public void SelectLevel4()
    {
        if (Padlocks[3].activeSelf == false)
            SceneManager.LoadScene("Level4");
    }

    public void SelectLevel5()
    {
        if (Padlocks[4].activeSelf == false)
            SceneManager.LoadScene("Level5");
    }
}
