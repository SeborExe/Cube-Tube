using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsStats : MonoBehaviour
{
    private const string CheckPoint = "CheckPoint";
    public static int GetActualDestroyed()
    {
        return PlayerPrefs.GetInt(CheckPoint, 0);
    }
    public static void SetCurrentDestroyedMeteors(int CheckPointNumber)
    {
        PlayerPrefs.SetInt(CheckPoint, CheckPointNumber);
    }
}
