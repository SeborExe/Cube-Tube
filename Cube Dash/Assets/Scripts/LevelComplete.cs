using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    CrystalCounter crystalCounter;
    public GameObject[] Stars;
    public Text MoneyText;
    public void LoadNextLevel()
    {
        crystalCounter = FindObjectOfType<CrystalCounter>();
        var level = SceneManager.GetActiveScene().name;          //Np. Level2
        var next = SceneManager.GetActiveScene().buildIndex + 1; //Np. 2Unlocked

        var crystals = FindObjectsOfType<Crystal>();
        var crystalCount = crystals.Length;
        var crystalInactive = crystals.Count(crystal => !crystal.Active);

        if (crystalInactive >= Mathf.Ceil(crystalCount / 5) && crystalInactive < Mathf.Ceil(crystalCount / 2))
        {
            Stars[0].SetActive(false);
            Stars[1].SetActive(true);
            PlayerPrefs.SetInt(next + "Unlocked", 1);

            if (PlayerPrefs.GetInt(level) == 0)
            {
                PlayerPrefs.SetInt(level, 1);
                LevelStats.SetAllStars(1);
                //Debug.Log(PlayerPrefs.GetInt(level));
            }
        }

        else if (crystalInactive >= crystalCount / 2 && crystalInactive < crystalCount / 1.25f)
        {
            Stars[0].SetActive(false);
            Stars[2].SetActive(true);
            PlayerPrefs.SetInt(next + "Unlocked", 1);

            if (PlayerPrefs.GetInt(level) == 1)
            {
                PlayerPrefs.SetInt(level, 2);
                LevelStats.SetAllStars(1);
                //Debug.Log(PlayerPrefs.GetInt(level));
            }

            else if (PlayerPrefs.GetInt(level) == 0)
            {
                PlayerPrefs.SetInt(level, 2);
                LevelStats.SetAllStars(2);
            }
        }

        else if (crystalInactive >= crystalCount / 1.25f)
        {
            Stars[0].SetActive(false);
            Stars[3].SetActive(true);
            PlayerPrefs.SetInt(next + "Unlocked", 1);

            if (PlayerPrefs.GetInt(level) == 0)
            {
                PlayerPrefs.SetInt(level, 3);
                LevelStats.SetAllStars(3);
                //Debug.Log(PlayerPrefs.GetInt(level));
            }
            
            else if (PlayerPrefs.GetInt(level) == 1)
            {
                PlayerPrefs.SetInt(level, 3);
                LevelStats.SetAllStars(2);
            }

            else if (PlayerPrefs.GetInt(level) == 2)
            {
                PlayerPrefs.SetInt(level, 3);
                LevelStats.SetAllStars(1);
            }
        }

        else
        {
            Stars[0].SetActive(true);
            PlayerPrefs.SetInt(next + "Unlocked", 1);
            //Debug.Log(next + "Unlocked");
        }
    }

    public void PlayNextLevel()
    {
        FindObjectOfType<GameManager>().completeLevelUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CheckPointsStats.SetCurrentCheckPoint(0);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TubeComplete()
    {
        SceneManager.LoadScene("TubesAndLevels");
    }
}
