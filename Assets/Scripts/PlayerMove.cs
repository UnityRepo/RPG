using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject TBScroll;
    public GameObject BTNCon;
    public GameObject playerText;
    public Text CNTBox;
    public Text CTTBox;
    public AudioSource textScroll;

    IEnumerator Start()
    {

        TBScrolling scroll = TBScroll.GetComponent<TBScrolling>();
        yield return StartCoroutine(scroll.CText("Unknown", "Come on, wake up!", 0, 1));
        yield return StartCoroutine(scroll.keyPress(0));
        yield return StartCoroutine(scroll.CText("Ok", "sus", 2, 1));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * 3f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 3f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * 3f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 3f * Time.deltaTime;
        }
    }
}
