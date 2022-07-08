using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectDrag : MonoBehaviour 
{
    private float dist;
    private bool dragging   = false;
    private Vector3 offset;
    private Transform toDrag;
    private LineRenderer line;
    private SpringJoint2D spring;
    public bool touch       = false;

    void Start() 
    {
        line = GetComponent<LineRenderer>();

        if (line != null)
        {
            spring = GetComponent<SpringJoint2D>();
            line.SetVertexCount(2);
        }   
    }

    void Update ()
    {
        if (line != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector3(spring.connectedAnchor.x, spring.connectedAnchor.y));
        }

        if (touch == true) 
        { 
            Vector3 v3;
            if (Input.touchCount > 0)
            {
                Vector3 firstWayPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (gameObject.GetComponent<CircleCollider2D>().OverlapPoint(firstWayPoint))
                {
                    dragging = true;
                }

                if (Input.touchCount != 1)
                {
                    dragging = false;
                    return;
                }

                Touch touch             = Input.touches[0];
                Vector3 uturePosition   = firstWayPoint;
                uturePosition.z         = 0;

                if (dragging && touch.phase == TouchPhase.Moved)//if player dragg the object
                {
                    gameObject.transform.position = uturePosition;
                }
                if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
                {
                    dragging = false;
                }
            }
        }
    }
}

