using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler : MonoBehaviour 
{
    public Sprite onSprite;
    public Sprite offSprite;
    private SpriteRenderer spriteRender;

    // Use this for initialization
    void Start () 
    {
        spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (Input.touchCount > 0) 
        {
            if (Input.GetTouch (0).phase == TouchPhase.Ended) 
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                checkIfSwitchHasTouch(wp);
            }
        }
    }

    private void checkIfSwitchHasTouch(Vector3 wp)
    {
        if (this.gameObject.GetComponent<CircleCollider2D>().OverlapPoint (wp)) 
        {
            changeSpriteImage();
        }
    }

    private void changeSpriteImage()
    {
        if(spriteRender.sprite == onSprite)
        {
            spriteRender.sprite = offSprite;
        }
        else
        {
            spriteRender.sprite = onSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            changeSpriteImage();
        }
    }
}
