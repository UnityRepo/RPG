using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockUnlock1 : MonoBehaviour
{
    public GameObject Key;

    public Sprite lockedSprite; 
    public Sprite unlockedSprite;

    public BoxCollider2D door;

    public bool locked = true;
    bool obtained;

    public AudioSource openDoor;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Key.SetActive(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        KeyDetect1 key = Key.GetComponent<KeyDetect1>();
        if (locked)
        {
            spriteRenderer.sprite = lockedSprite;
            door.enabled = true;
            
        }
        else if (locked == false)
        {
            spriteRenderer.sprite = unlockedSprite;
            door.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        KeyDetect1 key = Key.GetComponent<KeyDetect1>();
        if (key.obtained)
        {
            locked = false;
            key.obtained = false;
            Key.SetActive(false);
            openDoor.Play();
        }
    }
}
