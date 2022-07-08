using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhoto : MonoBehaviour 
{
    public GameObject background;
    public Sprite[] backgrounds;

    float timer = 1f;
    float delay = 1f;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () 
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if(spriteRenderer.sprite == backgrounds[0])
            {
                spriteRenderer.sprite	= backgrounds[0];
                timer					= delay;
                return;
            }
            if(spriteRenderer.sprite == backgrounds[1])
            {
                spriteRenderer.sprite	= backgrounds[1];
                timer					= delay;
                return;
            }
            if(spriteRenderer.sprite== backgrounds[2])
            {
                spriteRenderer.sprite	= backgrounds[2];
                timer					= delay;
                return;
            }
        }
    }
}
