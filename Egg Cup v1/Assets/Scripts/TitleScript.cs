using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    public NavigationScript nav;

    // Start is called before the first frame update
    void Start()
    {
        if(nav == null)
        {
            nav = GetComponent<NavigationScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            nav.NextScreen("PlayScene");
        }
    }
}
