using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    public NavigationScript nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = nav ?? GameObject.Find("NavigationPanel").GetComponent<NavigationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.Navigation();

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.R))
        {
            nav.NextScreen("PlayScene");
        }
    }
}
