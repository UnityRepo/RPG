using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject BlackScreen;

    public GameObject tipsContainer;

    public bool unclickable;
    public bool onTipsScreen;

    public void close()
    {
        if (unclickable == false)
        {
            Application.Quit();
        }
    }

    public void closeTips()
    {
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        tipsContainer.SetActive(false);

        if (unclickable == true)
        {
            unclickable = false; onTipsScreen = false;

            SmokeScreen.color = new Color(0, 0, 0, 0);
        }
    }

    public void tips()
    {
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        tipsContainer.SetActive(true);

        if (unclickable == false)
        {
            unclickable = true; onTipsScreen = true;

            SmokeScreen.color = new Color(0, 0, 0, 0.95f);
        }
    }

    public void play()
    {
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        if (unclickable == false) {

            SmokeScreen.color = new Color(0, 0, 0, 0);
            StartCoroutine(FadeIn(SmokeScreen));
        }
    }

    IEnumerator FadeIn(SpriteRenderer SmokeScreen)
    {
        SmokeScreen.color = new Color(0, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.1f);

        SmokeScreen.color = new Color(0, 0, 0, 0.4f);
        yield return new WaitForSeconds(0.1f);

        SmokeScreen.color = new Color(0, 0, 0, 0.6f);
        yield return new WaitForSeconds(0.1f);

        SmokeScreen.color = new Color(0, 0, 0, 0.8f);
        yield return new WaitForSeconds(0.1f);

        SmokeScreen.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Chapter");
    }
}
