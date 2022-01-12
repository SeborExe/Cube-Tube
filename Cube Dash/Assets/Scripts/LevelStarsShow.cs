using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarsShow : MonoBehaviour
{
    public GameObject[] LevelStars;

    [SerializeField]
    public int number;
    void Start()
    {
        var level = "Level" + number;

            if (PlayerPrefs.GetInt(level) == 1)
            {
                LevelStars[1].SetActive(true);
                LevelStars[0].SetActive(false);
            }

            else if (PlayerPrefs.GetInt(level) == 2)
            {
                LevelStars[2].SetActive(true);
                LevelStars[0].SetActive(false);
            }

            else if (PlayerPrefs.GetInt(level) == 3)
            {
                LevelStars[3].SetActive(true);
                LevelStars[0].SetActive(false);
            }

            else
                LevelStars[0].SetActive(true);
    }
}
