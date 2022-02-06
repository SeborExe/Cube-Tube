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
        SelectLevels.GetComponent<Animator>().Play("PrologueTubeLevels");
        Levels[0].GetComponent<Animator>().SetTrigger("prologue");
    }

    public void BackToLevels()
    {
        Levels[0].GetComponent<Animator>().Play("PrologueLevelsBackBehindeScene");
        SelectLevels.GetComponent<Animator>().Play("PrologueTubeLevelsBackToScreen");
    }
}
