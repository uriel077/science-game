using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  LaserCodePls: MonoBehaviour 
{
    public float range				= 1000;
    private LineRenderer line;
    public bool playerOnly			= true;
    private Collider2D collider;
    public GameObject onoffable;
    public float timer				= 0;
    public float timer1				= 0;
    public float maxtimer			= 0.1f;
    public int max					= 3;
    public string spawnedBeamTag	= "Through";
    private int i;
    public int maxsplit				= 10;

    void Start ()
    {
        line = GetComponent<LineRenderer> ();
        line.SetVertexCount (max);
    }

    void Update () // consider void FixedUpdate()
    {
        if (gameObject.tag != spawnedBeamTag) 
        {
            if (timer >= maxtimer)
            {
                if (gameObject.activeInHierarchy == true && onoffable != null)
                {
                    timer1 += 1;
                    if (timer1 >= maxtimer * 100)
                    {
                        timer1 = 0;
                        onoffable.SetActive(false);
                    }
                }

                timer = 0;

                foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(spawnedBeamTag))
                {
                    Destroy(laserSplit);
                }

                StartCoroutine (laser ());
            }

            timer += Time.deltaTime;

        } 
        else 
        {
            line = gameObject.GetComponent<LineRenderer>();
            StartCoroutine (laser ());
        }

    }

    IEnumerator laser()
    {
        int lasersplit  = 0;
        bool nohit      = true;
        i               = 1;
        line.SetPosition(0, transform.position);
        Vector2 laserPosition = transform.position;
        i++;
        line.endColor = Color.red;
        //while (nohit==true){
        lasersplit++;

        RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right, range); // transform.position + (transform.right * (float)offset) can be used for casting not from center.
        foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(spawnedBeamTag)) 
        {
            lasersplit++;
            if (lasersplit > maxsplit) 
            {
                yield break;
            }
        }
        if (i >= max-1)
            nohit = false;
        if (hit) 
        {
        //Vector3 reflect=Vector3.Reflect (transform.right, hit.normal);
            collider = hit.collider;
            line.SetPosition (1, hit.point);
            line.SetPosition (2, hit.point);
            if (collider.gameObject.tag == "sensor" && onoffable!=null) 
            {
                onoffable.SetActive (true);
            }
            else if ( collider.gameObject.tag == "Player") 
            {
                // Register hit.
            }
            else if ( collider.gameObject.tag == "Mirror") 
            {
                //Debug.Log("Split");
                if (lasersplit <= maxsplit) 
                    {
                    lasersplit++;
                    //Debug.Log (hit.normal);
                    Vector2 reflectVector = Vector2.Reflect(laserPosition - hit.point, hit.normal);
                   
                    
                    //reflect = Vector3.Reflect (reflect, hit.normal);
                    //Vector3 reflect =hit.normal*3;
                    //c = Vector2.Reflect(reflect, -c);
                    line.SetPosition (1, hit.point);
                    //line.SetPosition (2, -reflect);
                    Debug.DrawRay( hit.point, -reflectVector, Color.green);
                    float laserAngle    = Vector2.Angle(laserPosition - hit.point, reflectVector);

                    Quaternion q        = Quaternion.Euler(0,0, laserAngle);
                    // Quaternion q = Quaternion.AngleAxis(laserAngle, Vector3.forward);

                    Vector2 positionChild = hit.point ;
                    if (gameObject.transform.position.x - hit.point.x > 0)
                    {
                        positionChild.x += .1f;

                    }
                    else
                    {
                        positionChild.x -= .1f;

                    }

                    if (gameObject.transform.position.y - hit.point.y > 0)
                    {
                        positionChild.y -= .1f;

                    }
                    else
                    {
                        positionChild.y += .1f;

                    }

                    Object go               = Instantiate (gameObject, positionChild, q);
                    go.name                 = Vector2.Angle(laserPosition, -reflectVector) +"";
                    ((GameObject)go).tag    = spawnedBeamTag;
                    //yield return new WaitForEndOfFrame ();
                }
            }
            else if ( collider.gameObject.tag == "invisible") 
            {
                Physics2D.IgnoreCollision (hit.collider,hit.collider);
            }
            } 
            else 
            {
                nohit = false;
                line.SetPosition (1, transform.position + (transform.right * range)); // (transform.right * ((float)offset + range)) can be used for casting not from center.
                line.SetPosition (2, line.GetPosition(1)); // (transform.right * ((float)offset + range)) can be used for casting not from center.
            }

            i++;
        //}
        /*for (; i <= max-1; i++) {

            line.SetPosition (i, line.GetPosition(i-1)); // (transform.right * ((float)offset + range)) can be used for casting not from center.


        }*/
        yield return new WaitForEndOfFrame ();
    }
}
