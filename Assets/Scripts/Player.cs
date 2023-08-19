using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject TBScroll; //textbox scrolling script

    public AudioSource textScroll; //duh textscrolling audio

    public GameObject Navi; //fairyyyyyyyyyyyyyyyyyyy

    public GameObject BlackScreen;

    public Rigidbody2D rg;

    public Animator animator;

    public GameObject PauseScreen;


    IEnumerator Start() //corutine? im not sure
    {
        PauseScreen.SetActive(false);

        animator.SetBool("Sleeping", true);

        Navi.transform.position = new Vector3 (-12, 0.15f, 0); //scratch ptsd

        TBScrolling text = TBScroll.GetComponent<TBScrolling>(); //yoinkinng scrolling script

        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        SmokeScreen.color = new Color(0, 0, 0, 1);

        //dialog engine. (im so proud. kinda buggy tho)
        yield return StartCoroutine(text.CText("itdytfs", "", 1, 1));

        yield return StartCoroutine(text.CText("Unknown", "Come on, wake up!", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("You", "*mmh*", 0, 1));
        yield return StartCoroutine(text.keyPress(1));

        yield return new WaitForSeconds(0.5f);
        SmokeScreen.color = new Color(0, 0, 0, 0.8f);

        yield return new WaitForSeconds(0.5f);
        SmokeScreen.color = new Color(0, 0, 0, 0.6f);

        yield return new WaitForSeconds(0.5f);
        SmokeScreen.color = new Color(0, 0, 0, 0.4f);

        yield return new WaitForSeconds(0.5f);
        SmokeScreen.color = new Color(0, 0, 0, 0.2f);

        yield return new WaitForSeconds(0.5f);
        SmokeScreen.color = new Color(0, 0, 0, 0);

        animator.SetBool("Sleeping", false);

        yield return StartCoroutine(text.CText("You", "*You wake up*", 2, 1));
        yield return StartCoroutine(text.keyPress(1));

        yield return StartCoroutine(text.CText("Spirit", "Oh, so you're finally awake.", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("Spirit", "You ask who I am?", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("Spirit", "Already jumping to questions now are we?", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("Spirit", "I'm Spirit!", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("Spirit", "Why am I outside, you ask?", 1, 1));
        yield return StartCoroutine(text.keyPress(1));

        yield return StartCoroutine(text.CText("Spirit", "I don't know.", 1, 1));
        yield return StartCoroutine(text.keyPress(1));

        yield return StartCoroutine(text.CText("Spirit", "Just to teaching you some mechanics.", 1, 1));
        yield return StartCoroutine(text.keyPress(1));

        yield return StartCoroutine(text.CText("Spirit", "Speaking of, I need to tell you something!", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("Spirit", "I would prefer if you were to come outside first.", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        yield return StartCoroutine(text.CText("Spirit", "There should be a key to get outside.", 1, 1));
        yield return StartCoroutine(text.keyPress(0));

        text.close(); //"closing" the engine
    }
    private void Update() //why private void? idk. autocorrect
    {
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        TBScrolling text = TBScroll.GetComponent<TBScrolling>(); //yoinking again cuz im trash

        //player movement? is the rigidbody an option to move?

        if (text.paused == false)
        {

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("Walking", true);
                transform.position += Vector3.up * 4f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Walking", true);
                transform.position += Vector3.left * 4f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Walking", true);
                transform.position += Vector3.down * 4f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Walking", true);
                transform.position += Vector3.right * 4f * Time.deltaTime;
            } 
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                text.paused = true;
                SmokeScreen.color = new Color(0, 0, 0, 0.8f);
                Debug.Log("on");
                PauseScreen.SetActive(true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }
        }
    }

    public void Return()
    {
        TBScrolling text = TBScroll.GetComponent<TBScrolling>();
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        text.paused = false;
        SmokeScreen.color = new Color(0, 0, 0, 0);
        PauseScreen.SetActive(false);
    }

    public void Back()
    {
        TBScrolling text = TBScroll.GetComponent<TBScrolling>();
        SpriteRenderer SmokeScreen = BlackScreen.GetComponent<SpriteRenderer>();

        text.paused = false;
        SmokeScreen.color = new Color(0, 0, 0, 0);
        PauseScreen.SetActive(false);

        SceneManager.LoadScene("Title");
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        TBScrolling text = TBScroll.GetComponent<TBScrolling>();
        if (collision.name == "Spirit1")
        {
            yield return StartCoroutine(text.CText("Spirit", "Nice!", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "You made it out!", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Anyways, about what I wanted to talk to you about...", 1, 1));
            yield return StartCoroutine(text.keyPress(2));

            yield return StartCoroutine(text.CText("Spirit", "Humans.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "You're probably wondering about why I'm making this so suspenseful...", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "or, you are wondering what I was saying about humans.", 1, 1));
            yield return StartCoroutine(text.keyPress(1));

            yield return StartCoroutine(text.CText("Spirit", "Basically, humans are being dumb again and falling into anarchy.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "5 world leaders are infected with some kind of virus that makes them dictators ", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "You probably think this is bad, and which it is.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Now, here's where you come in!", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "You are the god of death right?", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("You", "*shakes head*", 2, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "So basically, you are going to kill them all.", 1, 1));
            yield return StartCoroutine(text.keyPress(1));

            yield return StartCoroutine(text.CText("Spirit", "Why do you look confused?", 1, 1));
            yield return StartCoroutine(text.keyPress(1));

            yield return StartCoroutine(text.CText("Spirit", "Ok. Let explain further.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Once killed by you, the world leaders will return back to \u0022normal\u0022.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Once normal, the world leaders can fix the irreparable damage they caused.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Which is none of our concern.", 1, 1));
            yield return StartCoroutine(text.keyPress(1));

            yield return StartCoroutine(text.CText("Spirit", "Hmm?", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "How do we get there?", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Almost forgot.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Just follow the path. I'll explain when you get there.", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            text.close();

            Navi.transform.position = new Vector3(-4.2f, 19, 0);


        }
        else if (collision.name == "Spirit2")
        {
            yield return StartCoroutine(text.CText("Spirit", "Here it is!", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "A portal to the human world!", 1, 1));
            yield return StartCoroutine(text.keyPress(0));

            yield return StartCoroutine(text.CText("Spirit", "Hop in!", 1, 1));
            yield return StartCoroutine(text.keyPress(0));
            text.close();
        } 
        else if (collision.name == "portal")
        {
            transform.position = new Vector3(-12, 0.15f, 0); //placeholder
        }
    }
}

