using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetect1 : MonoBehaviour
{
    public bool obtained = false; //nah u aint obtained it yet

    public AudioSource keySound; //ok soundsss

    private Vector3 velocity = Vector3.zero; //idk chatgpt

    public Transform player; //more chatgpt
    public float delay = 0.5f; //even more chatgpt

    private void Update()
    {
        if (obtained == true)
        {
            Vector3 targetPosition = player.TransformPoint(new Vector3(0, 0, 0)); //just delayed moving idk
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, delay); //chatgpt actually p cool

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //trash again
    {
        if (obtained == false) //u dont got it??
        {
            obtained = true; //ok then u got it
            keySound.Play(); //SOUNDDDDDDDD
            
        }
    }
}
