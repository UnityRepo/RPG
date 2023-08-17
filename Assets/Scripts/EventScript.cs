using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private Collider2D[] colliders;

    public GameObject Engine;
    private void Start()
    {
        colliders = GetComponentsInChildren<Collider2D>();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        TBScrolling text = Engine.GetComponent<TBScrolling>();
        Debug.Log("entered col");
        foreach (Collider2D collider in colliders)
        {
            if (collider.name == "Spirit1" && other.name == "Player")
            {
                yield return StartCoroutine(text.CText("Spirit", "Nice!", 1, 1));
                yield return StartCoroutine(text.keyPress(0));

                yield return StartCoroutine(text.CText("Spirit", "You made it out!", 1, 1));
                yield return StartCoroutine(text.keyPress(0));


                text.close();
            }
        }
    }
}
