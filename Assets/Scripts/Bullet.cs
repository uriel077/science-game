using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool freaze;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (freaze)
        {
            if (coll.gameObject.tag != "Player")
            {
                rb2d.velocity       = Vector3.zero;
                rb2d.freezeRotation = true;
                rb2d.constraints    = RigidbodyConstraints2D.FreezeAll;
            }
        }

        if (coll.gameObject.tag == "Pistachios")
        {
            Destroy(this.gameObject);
        }
    }
}
