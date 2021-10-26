using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PulsateText : MonoBehaviour {

    Text textObject;
    public float fadeRate;
    public float lowerLimit;

    void Start()
    {
        textObject = this.GetComponentInParent<Text>();
    }

	void Update () {

        float fadeDelta = Time.deltaTime * fadeRate;

        textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, textObject.color.a + fadeDelta);

        if (textObject.color.a + fadeDelta >= 1 || textObject.color.a + fadeDelta <= lowerLimit)
        {
            fadeRate = fadeRate * -1; //reverse fade
        }

        
	}
}
