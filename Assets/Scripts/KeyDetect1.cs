using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetect1 : MonoBehaviour
{
    public bool locked = true;

    public AudioSource keySound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        locked = false;
        keySound.Play();
    }
}
