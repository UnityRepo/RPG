using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject BlackScreen;

    public Button yourButton;
    // Start is called before the first frame update

    // Update is called once per frame

    public void close()
    {
        Application.Quit();
    }

    public void play()
    {
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        SmokeScreen.color = new Color(0, 0, 0, 0);
        StartCoroutine(FadeIn(SmokeScreen));
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
