using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    private new string name;
    public Transform padlock;
    private void Start()
    {   
        name = gameObject.name;
    }

    public void SelectThisLevel()
    {
        if (padlock.gameObject.activeSelf == false)
        {
            CheckPointsStats.SetCurrentCheckPoint(0);
            SceneManager.LoadScene(name);
        }
    }
}
