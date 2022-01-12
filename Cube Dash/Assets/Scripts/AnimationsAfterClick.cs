using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationsAfterClick : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject SelectLevels;
    public GameObject WhiteScreen;

    public void ShowPrologueLevels()
    {
        SelectLevels.GetComponent<Animator>().enabled = true;
        Levels[0].GetComponent<Animator>().enabled = true;
        //Debug.Log(PlayerPrefs.GetInt("Level2"));
    }

    public void BackToLevels()
    {
        SceneManager.LoadScene("TubesAndLevels");
        WhiteScreen.SetActive(true);
    }
}
