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
    [SerializeField] public AudioSource eggGroundSound;
    [SerializeField] public AudioSource coinCollect;

    // COIN COUNT

    public int Coin = 0;

    // COIN SOUND



    // Start is called before the first frame update
    void Start()
    {
        eggColl = GetComponent<Collider2D>();
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
            coinCollect.Play();
            Destroy(collision.gameObject);
            Coin = 1;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        eggGroundSound.Play();
    }
}

