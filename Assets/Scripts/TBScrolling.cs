using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBScrolling : MonoBehaviour
{
    public GameObject playerText;
    public Text CNTBox;
    public Text CTTBox;
    IEnumerator Start()
    {
        yield return StartCoroutine(CText("Unknown", "Come on, wake up!", 1,1));
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(CText("You", "*mmhh*", 0,1));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("", "*You wake up*", 0,1));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("You", "Who are you?", 0, 1));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("Spirit", "I'm Spirit!", 1, 1));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("Spirit", "and you are?", 1, 1));
    }


    void Update()
    {
        
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
            CTTBox.text = ctext.Substring(0, i + 1);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
