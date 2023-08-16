using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetect1 : MonoBehaviour
{
    public bool obtained = false;

    public AudioSource keySound;

    private Vector3 velocity = Vector3.zero;

    public Transform player;
    public float delay = 0.5f;

    private void Update()
    {
        if (obtained == true)
        {
            Vector3 targetPosition = player.TransformPoint(new Vector3(0, 0, 0));
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, delay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obtained == false)
        {
            obtained = true;
            keySound.Play();
            
        }
    }
}
