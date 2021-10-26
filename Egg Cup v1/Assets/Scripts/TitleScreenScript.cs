using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour {

    public NavigationScript nav;

	// Use this for initialization
	void Start () {
        nav = nav ?? GameObject.Find("NavigationPanel").GetComponent<NavigationScript>();
    }
	
	// Update is called once per frame
	void Update () {
        nav.Navigation();

        if(Input.anyKey)
        {
            PlayClicked();
        }
	}

    public void PlayClicked()
    {
        nav.NextScreen("PlayScene");
    }

    public void ExitClicked()
    {
        Application.Quit();
    }
}
