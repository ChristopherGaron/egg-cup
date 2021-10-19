using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public PlayerController player;
    public GameObject egg;
    public Text distanceText;

    private bool resetPressed;

    private float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void GetInputs()
    {
        resetPressed = Input.GetKey(KeyCode.R);
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        if(resetPressed)
        {
            SceneManager.LoadScene("PlayScene");
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
    }
}
