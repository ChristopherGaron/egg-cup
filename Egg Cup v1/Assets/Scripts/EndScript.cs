using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public NavigationScript nav;

    public Text TimePlayedText;
    public Text TotalTimePlayedText;
    public Text DistanceText;
    public Text FurthestDistanceText;

    private float delayInput = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        nav = nav ?? GameObject.Find("NavigationPanel").GetComponent<NavigationScript>();

        TimePlayedText.text = ((TimeSpan)(DateTime.Now - ScoreData.GameStart)).ToString(@"hh\:mm\:ss");
        TotalTimePlayedText.text = ((TimeSpan)(DateTime.Now - ScoreData.SessionStart)).ToString(@"hh\:mm\:ss");
        DistanceText.text = string.Format("{0:0}m", ScoreData.CurrentDistance);
        FurthestDistanceText.text = string.Format("{0:0}m", ScoreData.FurthestDistance);
    }

    // Update is called once per frame
    void Update()
    {
        nav.Navigation();

        if (delayInput < 0 && Input.anyKey)
        {
            nav.NextScreen("PlayScene");
        }

        delayInput -= Time.deltaTime;
    }
}
