using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreData
{ 

    public static DateTime SessionStart = DateTime.Now;
    public static DateTime GameStart = DateTime.Now;
    public static float CurrentDistance = 0f;
    public static float FurthestDistance = 0f;

    public static void ResetTempScores()
    {
        CurrentDistance = 0;
        GameStart = DateTime.Now;
    }
}
