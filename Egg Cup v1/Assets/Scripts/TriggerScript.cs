using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public JumpPadScript JumpPad;
    // Start is called before the first frame update
    void Start()
    {
        JumpPad = transform.parent.GetComponent<JumpPadScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JumpPad.FireJumpPad();
    }
}
