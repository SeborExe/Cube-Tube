using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelStats
{
    private const string All_Stars = "all_stars";
    private const string Highest_Level = "highest_level";

    public static void SetAllStars(int points)
    {
        var ActualStars = GetAllStars();
        PlayerPrefs.SetInt(All_Stars, ActualStars + points);
    }

    public static int GetAllStars()
    {
        return PlayerPrefs.GetInt(All_Stars, 0);
    }

    public static int GetHighestLevel()
    {
        return PlayerPrefs.GetInt(Highest_Level, 0);
    }

    public static void SetHighestLevel(int level)
    {
        PlayerPrefs.SetInt(Highest_Level, level);
    }
}
