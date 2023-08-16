using System.Collections;
using System.Collections.Generic;
using System.Threading; //uneccary
using UnityEngine;
using UnityEngine.UI;

public class TBScrolling : MonoBehaviour
{
    public GameObject UITextOBJ; //textbox engine container

    public GameObject Looker; //camera. cant use the word camera tho so...
    public Transform Player; //duh. follow camera stuff

    public GameObject TBody; //dialog underlay thing
    public GameObject playerText; //character name background thing (i got it wrong)

    public GameObject ConCon; //god i hate transform animations. btncon container parent thing. im trying to sound smart here

    public Text CNTBox; //ACTUAL character name text BOX
    public Text CTTBox; //im so bad at naming things.

    public AudioSource textScroll; //textscrolling audio
    public bool paused; //main paused boolean

    public void Update() //again private void? idk what that does???
    {
        Looker.transform.position = new Vector3(Player.position.x, Player.position.y, Player.position.z + -5f); //camera position locked to player. i tried parenting.
    }



    public IEnumerator keyPress(float waitTime) //easier wait time stuff
    {
        yield return new WaitForSeconds(waitTime);
        ConCon.SetActive(true);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        ConCon.SetActive(false);
    }
    public void close() //hiding literally everything humanly possible
    {
        paused = false;

        CNTBox.text = "";
        CTTBox.text = "";


        UITextOBJ.SetActive(false);

    }
    public IEnumerator CText(string cname, string ctext, int positioning, float baseSpeed) //crying because this took me 3 days. yes im not new to the grind.
    {
        UITextOBJ.SetActive(true);
        paused = true;
        ConCon.SetActive(false);

        float speed = baseSpeed / 100; //eaiser speed modifier
        if (positioning == 0) //left
        {
            playerText.transform.position = new Vector3(Player.position.x - 4.75f,Player.position.y - 1.2f, 0f);
            CNTBox.transform.position = new Vector3(500f, 416f, 0f);
        } else if (positioning == 1) //right
        {
            playerText.transform.position = new Vector3(Player.position.x + 6f, Player.position.y - 1.2f, 0f);
            CNTBox.transform.position = new Vector3(1620f, 416f, 0f);
        } else if (positioning == 2) //gone
        {
            playerText.transform.position = new Vector3(Player.position.x - 261.2001f, Player.position.y - 218.0f, 0.0f);
            CNTBox.transform.position = new Vector3(-261.2001f, -218.0f, 0.0f);
        }

        TBody.transform.position = new Vector3(Player.position.x + 2, Player.position.y - 3.1f, Player.position.z - 4.5f); //some reason for the teleport textbox script thing is here. wait nevermind it makes total sense.
        ConCon.transform.position = new Vector3(Player.position.x, Player.position.y, 0); //since?

        float waitTime; //2 waittime variables
        CNTBox.text = cname + ":";
        for (int i = 0; i < ctext.Length; i++) //garbage for repeat for length
        {
            if (Input.GetKey(KeyCode.Return)) //faster if key pressed for longer
            {
                waitTime = speed;
            } else
            {
                waitTime = speed + 0.04f;
            }

            textScroll.Play(); //sound

            CTTBox.text = ctext.Substring(0, i + 1); //god python is easier with this stuff

            yield return new WaitForSeconds(waitTime); //how long to wait for each letter
        }
    }
}
