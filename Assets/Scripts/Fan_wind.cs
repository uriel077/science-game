using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_wind : MonoBehaviour {

    public int timer    = 0; 
    public int maxtimer = 50; 
    public float speed  = 1f, fanRot;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () 
    {
        if (gameObject.activeInHierarchy == true) 
        {
            Vector2 v       = rb2d.velocity;
            timer           += 1;
                
            if (timer >= maxtimer) 
            {
                Destroy (gameObject);
                return;
            }

            v.x             = speed * Mathf.Sin (fanRot);
            v.y             = speed * Mathf.Cos(fanRot);
            rb2d.velocity   = v;
    }
    }}
