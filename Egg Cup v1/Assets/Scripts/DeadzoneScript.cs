using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadzoneScript : MonoBehaviour
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Egg" || collision.gameObject.tag == "Player")
        {
            nav.NextScreen("LoseScene");
        }
    }
}
