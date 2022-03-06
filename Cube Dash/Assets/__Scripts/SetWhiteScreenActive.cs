using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetWhiteScreenActive : MonoBehaviour
{
    public GameObject WhiteScreen;
    public void GoToTubesSelect()
    {
        WhiteScreen.SetActive(false);
    }
}
