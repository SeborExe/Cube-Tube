using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    private new string name;
    private Transform padlock;
    private void Start()
    {   
        name = gameObject.name;
        padlock = gameObject.transform.Find("Padlock");
    }

    public void SelectThisLevel()
    {
        if (padlock == null)
        {
            CheckPointsStats.SetCurrentCheckPoint(0);
            SceneManager.LoadScene(name);
        }
    }
}
