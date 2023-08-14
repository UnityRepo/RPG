using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TBScrolling : MonoBehaviour
{

    public GameObject TBScroll;
    public GameObject BTNCon;
    public GameObject playerText;
    public Text CNTBox;
    public Text CTTBox;
    public AudioSource textScroll;

    public IEnumerator keyPress(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        BTNCon.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        BTNCon.SetActive(false);

    }
    public IEnumerator CText(string cname, string ctext, int positioning, float baseSpeed)
    {
        float speed = baseSpeed / 100;
        if (positioning == 0) //left
        {
            playerText.transform.position = new Vector3(-4.75f, -1.2f, 0f);
            CNTBox.transform.position = new Vector3(500f, 416f, 0f);
        } else if (positioning == 1) //right
        {
            playerText.transform.position = new Vector3(6f, -1.2f, 0f);
            CNTBox.transform.position = new Vector3(1620f, 416f, 0f);
        } else if (positioning == 2) //gone
        {
            playerText.transform.position = new Vector3(-261.2001f, -218.0f, 0.0f);
            CNTBox.transform.position = new Vector3(-261.2001f, -218.0f, 0.0f);
        }
        float waitTime;
        CNTBox.text = cname + ":";
        for (int i = 0; i < ctext.Length; i++)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                waitTime = speed;
            } else
            {
                waitTime = speed + 0.04f;
            }
            textScroll.Play();
            CTTBox.text = ctext.Substring(0, i + 1);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
