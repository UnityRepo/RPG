using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBScrolling : MonoBehaviour
{
    public Text CNTBox;
    public Text CTTBox;
    IEnumerator Start()
    {
        yield return StartCoroutine(CText("Person", "Good morning!"));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("Person", "How are you today?"));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return StartCoroutine(CText("Person", " bv fv h gf yjdfbbsfjb fd hf h vdf sf bh dfjh xfjhb xg bhjbhj biudbgk sgsudbgisdubsudbg usdbgusdfbgsdgbi sudgu b"));
    }


    void Update()
    {
        
    }
    public IEnumerator CText(string cname, string ctext)
    {
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
