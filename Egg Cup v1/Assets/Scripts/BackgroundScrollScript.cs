using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollScript : MonoBehaviour
{
    private Material backgroundImage;
    public  Vector2 offsetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImage.mainTextureOffset += offsetSpeed * Time.deltaTime;
    }
}
