using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBScrolling : MonoBehaviour
{
    public Text CNTBox;
    public Text CTTBox;
    void Start()
    {
        StartCoroutine(CText("Name", "Actually, it is scientificlly impossible to kuysdffkguy sfady gasdfhashdf", 0.05f));
    }


    void Update()
    {
        
    }
    public IEnumerator CText(string cname, string ctext, float waitTime)
    {
        CNTBox.text = cname + ":";
        for (int i = 0; i < ctext.Length; i++)
        {
            CTTBox.text = ctext.Substring(0, i + 1);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
//yaa