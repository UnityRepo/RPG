using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockUnlock1 : MonoBehaviour
{
    public GameObject Key; //actually necessary

    public Sprite lockedSprite; //locked and unlocked door sprites
    public Sprite unlockedSprite; 

    public BoxCollider2D door; //door activ?

    public bool locked = true; //is the door locked????

    public AudioSource openDoor; //sfx babeeee

    public SpriteRenderer spriteRenderer; //change of sprites

    void Start()
    {
        Key.SetActive(true); //WOw tHe KEy iS aCTiVe
    }

    void Update()
    {
        KeyDetect1 key = Key.GetComponent<KeyDetect1>(); //yoinking script

        if (locked) //is it locked?
        {
            spriteRenderer.sprite = lockedSprite;
            door.enabled = true;
            
        }
        else if (locked == false) //nah, it aint locked
        {
            spriteRenderer.sprite = unlockedSprite;
            door.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //im trash, ok?
    {
        KeyDetect1 key = Key.GetComponent<KeyDetect1>(); //yoinking script again

        if (key.obtained) //u got key?
        {
            locked = false; //alr imma not ock
            key.obtained = false; //change to not obtained
            Key.SetActive(false); //snaps it from existince
            openDoor.Play(); //oh look a sound
        }
    }
}
