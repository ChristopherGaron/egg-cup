using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameScript : MonoBehaviour
{
    public PlayerController player;
    public GameObject egg;
    public Text distanceText;

    private bool resetPressed;
    private bool pausePressed;
    public bool gamePaused;

    private float maxDistance;

    public NavigationScript nav;

    public GameObject PauseMenu;

    public MusicScript Music;
    public Slider MusicSlider;
    public Slider SfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        nav = nav ?? GameObject.Find("NavigationPanel").GetComponent<NavigationScript>();
        ScoreData.ResetTempScores();

        Music = GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<MusicScript>();
        MusicSlider.value = Music.MusicVolume;
        SfxSlider.value = Music.SfxVolume;

    }

    private void GetInputs()
    {
        if (!gamePaused)
        {
            resetPressed = Input.GetKey(KeyCode.R);
        }

        pausePressed = Input.GetKeyDown(KeyCode.Escape);


    }

    // Update is called once per frame
    void Update()
    {
        nav.Navigation();
        GetInputs();

        if(resetPressed)
        {
            ResetLevel();
        }

        if(pausePressed)
        {
            if(gamePaused)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                gamePaused = false;
                player.freezeInput = false;
            }
            else
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                gamePaused = true;
                player.freezeInput = true;
            }
        }

        //get distance of egg in cup
        if(player.hasEgg)
        {
            if(egg.transform.position.x > maxDistance)
            {
                maxDistance = egg.transform.position.x;
                SetScore();
            }
        }
    }

    private void SetScore()
    {
        distanceText.text = Mathf.RoundToInt(maxDistance).ToString() + "m";
        ScoreData.CurrentDistance = maxDistance;
        ScoreData.FurthestDistance = maxDistance > ScoreData.FurthestDistance ? maxDistance : ScoreData.FurthestDistance;
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }

    public void SetMusicVolume(float value)
    {
        Music.SetMusicVolume(value);
    }

    public void SetSfxVolume(float value)
    {
        Music.SetSfxVolume(value);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
