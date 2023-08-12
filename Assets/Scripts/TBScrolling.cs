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
        yield return StartCoroutine(CText("Person", "Good morning!", 0));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("Person", "How are you today?", 0));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("Person", " bv fv h gf yjdfbbsfjb fd hf h vdf sf bh dfjh xfjhb xg bhjbhj biudbgk sgsudbgisdubsudbg usdbgusdfbgsdgbi sudgu b", 1));
    }


    void Update()
    {
        
    }
    public IEnumerator CText(string cname, string ctext, int positioning)
    {
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
                waitTime = 0.01f;
            } else
            {
                waitTime = 0.05f;
            }
            CTTBox.text = ctext.Substring(0, i + 1);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
