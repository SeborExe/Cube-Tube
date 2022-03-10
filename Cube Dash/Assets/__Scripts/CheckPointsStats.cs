using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsStats : MonoBehaviour
{
    private const string CheckPoint = "CheckPoint";
    public static float GetActualCheckPoint()
    {
        return PlayerPrefs.GetFloat(CheckPoint, 0);
    }
    public static void SetCurrentCheckPoint(float CheckPointNumber)
    {
        PlayerPrefs.SetFloat(CheckPoint, CheckPointNumber);
    }
}
