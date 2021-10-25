using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationScript : MonoBehaviour {

    public GameObject fadePanel;
    private Image fadePanelImage;
    public float fadeTime;
    float fadeElapsed;
    string nextScreen;

    // Use this for initialization
    void Start()
    {
        fadePanel.SetActive(true);
        fadePanelImage = fadePanel.GetComponent<Image>();
    }

    public void Navigation()
    {
        if (string.IsNullOrEmpty(nextScreen))
        {
            FadeIn();
        }
        else
        {
            if (FadeOut())
            {
                SceneManager.LoadScene(nextScreen);
            }
        }
    }

    public void NextScreen(string ns)
    {
        if (ns != nextScreen)
        {
            nextScreen = ns;
            fadeElapsed = 0;
        }
    }

    void FadeIn()
    {
        if (fadeElapsed < fadeTime)
        {
            var col = fadePanelImage.color;

            col.a = 1 - (1 * (fadeElapsed / fadeTime));

            fadePanelImage.color = col;

            fadeElapsed += Time.deltaTime;
        }
        else
        {
            fadePanel.SetActive(false);
        }
    }

    bool FadeOut()
    {
        fadePanel.SetActive(true);

        if (fadeElapsed < fadeTime)
        {
            var col = fadePanelImage.color;

            col.a = (1 * (fadeElapsed / fadeTime));

            fadePanelImage.color = col;

            fadeElapsed += Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }
}
