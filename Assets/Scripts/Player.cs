using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{

    public float speed          = 50f;
    public float bulletspeed    = 1999f;
    public float jumpPower      = 150f;
    public float maxSpeed       = 3f;
    public float antigravity    = 9f;
    public float outofrange     = -30f;
    public bool grounded;
    public float resistance     = 5f;
    private Rigidbody2D rb2d;
    private bool butontochr     = false;
    private bool butontochl     = false;
    public GameObject leftBox;
    public GameObject rightBox;
    public GameObject menu;
    public GameObject exit;
    public GameObject next;
    public GameObject endtext;
    public Transform parachute;
    public GameObject bparachute;
    public GameObject bshoot;
    public GameObject panelToAttachButtonsTo;
    public GameObject projectile;
    public GameObject bulletcase;
    private GameObject prevprojectile;
    private GameObject prevbulletcase;
    public bool WithGun         = false;
    private int collisionCount  = 0;

    void Start () 
    {
        rb2d = gameObject.GetComponent<Rigidbody2D> ();
        menu.SetActive (false);
        endtext.SetActive (false);

        if (bparachute != null)
        {

            bparachute              = (GameObject)Instantiate(bparachute, panelToAttachButtonsTo.transform);
            bparachute.GetComponent<Button>().onClick.AddListener(openparachute);//Setting what button does when clicked

            parachute               = (Transform)Instantiate(parachute, gameObject.transform);

            parachute.localScale    = new Vector3(0.9F / transform.localScale.x, 0.9F / transform.localScale.y, 1);
            parachute.localPosition = new Vector3(0, 3.9f/ transform.localScale.y,0);
        }

        if (bshoot != null && WithGun)
        {

            bshoot = (GameObject)Instantiate(bshoot, panelToAttachButtonsTo.transform);
            bshoot.GetComponent<Button>().onClick.AddListener(shoot);//Setting what button does when clicked
            bshoot.SetActive(true);

        }

        if (PlayerPrefs.GetString("levelpass" + (Application.loadedLevel -1)) != "1" && (Application.loadedLevel ) > 2 && next != null)
        {
            next.SetActive(false);

        }

        Time.timeScale = 1;
    }

    void LateUpdate()
    {
        if (bparachute != null)
        {
            if (Mathf.Abs(rb2d.velocity.y )> 3) 
            { 
                bparachute.SetActive(true); 
            }
           // else bparachute.SetActive(false);
        }
       
    }
    // Update is called once per frame
    void Update () 
    {
        if (bparachute != null) 
        {
            if (collisionCount == 0)
            {
                bparachute.SetActive(true);
            }
        }

        butontochr  = false;
        butontochl  = false;

        if (Input.touchCount > 0) 
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
            TouchLeftBox (wp);
            TouchRightBox (wp);
        }

        if (rb2d.position.y < outofrange) 
        {
            Restart();
        }

        if (Input.GetAxis ("Horizontal") < 0.1f) 
        {
        //	transform.localScale = new Vector3 (-1,1,1);
        }
        if (Input.GetAxis ("Horizontal") >0.1f) 
        {
        //	transform.localScale = new Vector3 (1,1,1);
        }

        if (butontochl == false && butontochr == false && grounded == true)
        {
            if (rb2d.velocity.x != 0) 
            {
                int v = 2;
                if (rb2d.velocity.x > 0) 
                {
                    rb2d.AddForce(new Vector2(-v, 0));
                } 
                else 
                {
                    rb2d.AddForce(new Vector2(v, 0));
                }
            } 
            else if(rb2d.velocity.y <= 0) 
            {
                rb2d.AddForce(new Vector2(0, resistance));
            }
            else 
            {
                rb2d.velocity= Vector3.zero;
            }
        }
        
    }
    void FixedUpdate()
    {
        //limit speed
        float h =Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed) 
        {
            rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed) 
        {
            rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
        }
    }
    
    private void TouchLeftBox(Vector3 wp)
    {
        butontochl = false;
        if (leftBox.GetComponent<BoxCollider2D> ().OverlapPoint (wp)) 
        {
            butontochl  = true;
            float h     = 1.5f;
            rb2d.AddForce((Vector2.left * speed) * h);

            if (rb2d.velocity.x < -maxSpeed) 
            {
                rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
            }
        }
    }

    private void TouchRightBox(Vector3 wp)
    {
        butontochr = false;
        if (rightBox.GetComponent<BoxCollider2D> ().OverlapPoint (wp)) 
        {
            butontochr  = true;
            float h     = 1.5f;
            rb2d.AddForce ((Vector2.right * speed) * h);

            if (rb2d.velocity.x > maxSpeed) 
            {
                rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
            }
        }
    }

    public void leftMovement()
    {
        transform.position += Vector3.left;
    }

    public void jumpBtn()
    {
        if (grounded) 
        {
            grounded = false;

            if (bparachute != null)
            {
                bparachute.SetActive(true);
            }

            rb2d.AddForce ((Vector2.up * speed) * antigravity);
        }
    }
    public void Restart()
    {
        rb2d.position   = new Vector3 (0, -0.1f, 0);
        rb2d.velocity   = Vector3.zero;
        rb2d.velocity   = new Vector2(0,0);

    }
    public void Finish()
    {
        menu.SetActive(true);
        endtext.SetActive(true);

        if (exit != null)
        {
            exit.SetActive(false);

        }

        if (((Application.loadedLevel - 1) < 30 && (Application.loadedLevel - 1)>0) && next != null)
        {
            next.SetActive(true);

        }

        if ((Application.loadedLevel - 1) < 31)
        {
            PlayerPrefs.SetString("levelpass" + (Application.loadedLevel - 1), "1");
        }
    }
    private void movescence()
    {
        if (Application.loadedLevel < Application.levelCount - 1)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        else
        {
            Application.LoadLevel(0);
        }
    }
    public void openparachute()
    {
        if (GetComponent<Rigidbody2D>().drag != 12)
        {
            transform.rotation                              = Quaternion.AngleAxis(0, Vector3.up);
            GetComponent<Rigidbody2D>().freezeRotation      = true;
            GetComponent<Rigidbody2D>().drag                = 12;
            parachute.GetComponent<SpriteRenderer>().color  = new Color(1, 1, 1, 1);
        }
        else
        {
       
            GetComponent<Rigidbody2D>().freezeRotation      = false;
            GetComponent<Rigidbody2D>().drag                = 0;
            parachute.GetComponent<SpriteRenderer>().color  = new Color(1, 1, 1, 0);
        }
    }
    public void shoot() 
    {
        //GameObject instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation) ;
        if (prevprojectile != null)
        {
            Destroy(prevprojectile, 3f);
        }
        if (prevbulletcase != null)
        {
            Destroy(prevbulletcase, 3f);
        }

        prevprojectile  = Instantiate(projectile, transform.position + 4.0f * transform.right, transform.rotation);
         //instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = instantiatedProjectile.transform.forward * 6;
        prevprojectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed);
        prevbulletcase  = Instantiate(bulletcase, transform.position + 2.2f * transform.right, transform.rotation);
        prevbulletcase.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletspeed / 10);
        // Destroy(prevprojectile, 2f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        collisionCount++;
        if(coll.gameObject.tag == "Pistachios")
        {
            Restart();
        }

        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "killer")
        {
            GetComponent<Rigidbody2D>().drag = 0;

            if (bparachute != null)
            {
                parachute.GetComponent<SpriteRenderer>().color  = new Color(1, 1, 1, 0);
                bparachute.SetActive(false);
                GetComponent<Rigidbody2D>().freezeRotation      = false;
            }

            grounded = true;
        }
        
        if (coll.gameObject.tag == "Finish")
        {
            Finish();
        }  
    }

    void OnCollisionExit()
    {
            collisionCount--;
    }
}
