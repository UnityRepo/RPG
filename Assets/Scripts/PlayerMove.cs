using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject TBScroll; //textbox scrolling script

    public AudioSource textScroll; //duh textscrolling audio


    IEnumerator Start() //corutine? im not sure
    {
        TBScrolling scroll = TBScroll.GetComponent<TBScrolling>(); //yoinkinng scrolling script

        //dialog engine. (im so proud. kinda buggy tho)

        yield return StartCoroutine(scroll.CText("Unknown", "Come on, wake up!", 1, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        yield return StartCoroutine(scroll.CText("You", "*mmh*", 0, 1));
        yield return StartCoroutine(scroll.keyPress(1));

        yield return StartCoroutine(scroll.CText("", "*You wake up*", 2, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        yield return StartCoroutine(scroll.CText("You", "Who are you?", 0, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        yield return StartCoroutine(scroll.CText("Unknown", "Me?", 1, 1));
        yield return StartCoroutine(scroll.keyPress(1));

        yield return StartCoroutine(scroll.CText("Spirit", "I'm Spirit!", 1, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        yield return StartCoroutine(scroll.CText("Spirit", "I can see that you're awake.", 1, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        yield return StartCoroutine(scroll.CText("Spirit", "Oh, I need to tell you something!", 1, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        yield return StartCoroutine(scroll.CText("Spirit", "Can you look for a key to get outside?", 1, 1));
        yield return StartCoroutine(scroll.keyPress(0));

        scroll.close(); //"closing" the engine
    }
    private void Update() //why private void? idk. autocorrect
    {
        TBScrolling scroll = TBScroll.GetComponent<TBScrolling>(); //yoinking again cuz im trash

        //player movement? is the rigidbody an oprioin to move?

        if (scroll.paused == false)
        {

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * 4f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * 4f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * 4f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * 4f * Time.deltaTime;
            }
        }
    }
}
