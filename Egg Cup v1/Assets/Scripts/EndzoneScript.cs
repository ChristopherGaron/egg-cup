using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndzoneScript : MonoBehaviour
{
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //win condition
        if(collision.gameObject.tag == "Player" && player.hasEgg)
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}
