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
    bool locked;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        KeyDetect1 scroll = Key.GetComponent<KeyDetect1>();
        if (scroll.locked)
        {
            spriteRenderer.sprite = lockedSprite;
            door.enabled = true;
        }
        else
        {
            spriteRenderer.sprite = unlockedSprite;
            door.enabled = false;

        }
    }
}
