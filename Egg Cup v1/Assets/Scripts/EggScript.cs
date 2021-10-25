using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{

    // CALLING THE EGG
    public GameObject egg;

    // START() VARIABLES
    private Collider2D eggColl;

    // CALLING GROUND COLLISION
    [SerializeField] private LayerMask ground;

    // CALLING THE SOUND
    public AudioSource eggGroundSound;

    // COIN COUNT

    public int Coin = 0;


    // Start is called before the first frame update
    void Start()
    {
        eggColl = GetComponent<Collider2D>();
        eggGroundSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // COIN COLL

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            Coin = 1;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        eggGroundSound.Play();
    }
}

