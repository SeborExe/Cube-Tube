using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelStats
{
    private const string All_Stars = "all_stars";

    public static void SetAllStars(int points)
    {
        var ActualStars = GetAllStars();
        PlayerPrefs.SetInt(All_Stars, ActualStars + points);
    }

    public static int GetAllStars()
    {
        return PlayerPrefs.GetInt(All_Stars, 0);
    }
}
