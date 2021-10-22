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


    // Start is called before the first frame update
    void Start()
    {
        eggColl = GetComponent<Collider2D>();
        eggGroundSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {

        // if (eggColl.IsTouchingLayers(ground))
        // {
        //     eggGroundSound.Play();
        // }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        eggGroundSound.Play();
    }
}

