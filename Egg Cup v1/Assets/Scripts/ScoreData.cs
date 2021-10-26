using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreData
{ 

    public static DateTime SessionStart;
    public static DateTime GameStart;
    public static float CurrentDistance;
    public static float FurthestDistance;


    public static void ResetTempScores()
    {
        CurrentDistance = 0;
        GameStart = DateTime.Now;
    }
}
