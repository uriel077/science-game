using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour 
{
    public float range      = 1000;
    private LineRenderer line;
    public bool playerOnly  = true;
    private Collider2D collider;
    public GameObject onoffable;
    public int timer        = 0; 
    public int maxtimer     = 200;
    public int max          = 4;
    private int i;

    void Start ()
    {
        line = GetComponent<LineRenderer> ();
        line.SetVertexCount (max);
    }

    void Update () // consider void FixedUpdate()
    {
        if (gameObject.activeInHierarchy == true && onoffable != null) 
        {
            timer += 1;

            if (timer >= maxtimer) 
            {
                timer = 0;
                onoffable.SetActive (false);
                return;
            }
        }

        bool nohit  = true;
        i           = 0;
        line.SetPosition (0, transform.position);
        i++;
        line.endColor = Color.cyan;

        while (nohit == true)
        {
            RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right, range); // transform.position + (transform.right * (float)offset) can be used for casting not from center.

            if (i >= max-1)
            {
                nohit = false;
            }
            
            if (hit) 
            {
                collider = hit.collider;
                line.SetPosition (i, hit.point);

                if (collider.gameObject.tag == "sensor" && onoffable != null) 
                {
                    onoffable.SetActive (true);
                }
                else if (collider.gameObject.tag == "Player") 
                {
                    // Register hit.
                }
                else if (collider.gameObject.tag == "Mirror") 
                {
                    //Debug.Log("Split");
                    Vector3 reflect= Vector3.Reflect(gameObject.transform.position, hit.normal);
                    line.SetPosition (1, hit.point);
                    line.SetPosition (2, -reflect);
                    return;
            
                }
                else if (collider.gameObject.tag == "invisible") 
                {
                    Physics2D.IgnoreCollision (hit.collider,hit.collider);
                }
            } 
            else 
            {
                  nohit = false;
                line.SetPosition (i, transform.position + (transform.right * range)); // (transform.right * ((float)offset + range)) can be used for casting not from center.
            }

            i++;
        }

        for (; i <= max-1; i++) 
        {
            line.SetPosition (i, line.GetPosition(i-1)); // (transform.right * ((float)offset + range)) can be used for casting not from center. 
        }
    }
}

