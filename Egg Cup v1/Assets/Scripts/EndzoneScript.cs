using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndzoneScript : MonoBehaviour
{
    public PlayerController player;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //win condition
        if(collision.gameObject.tag == "Player" && player.hasEgg)
        {
            nav.NextScreen("WinScene");
        }
    }
}
