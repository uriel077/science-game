using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using System;

public class ItsImposible : MonoBehaviour 
{
    public Transform target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //calculate path
    public Path path;
    //ai speed
    
    [HideInInspector]
    public bool pathisend = false;
    //the max distance 

    private int  currenwaypoint	    = 0;
    private bool allrightallright   = false;
    
    public float timer	= 0; 
    public int maxtimer	= 1;

    void Start()
    {
        allrightallright    = false;
        seeker              = GetComponent<Seeker>();
        rb                  = GetComponent<Rigidbody2D>();

        if (target == null) 
        {
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(UpdatePath());
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer >= maxtimer) 
        {
            timer = 0;
            //AstarPath.active.Scan ();
            if (allrightallright == true) {
                target.gameObject.SetActive(false);
                //AstarPath.active.Scan ();
            }
            //	return;
        }
    }

    IEnumerator UpdatePath()
    {
        if (target == null) 
        {
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds (1f / updateRate);
        StartCoroutine(UpdatePath ());

    }
    public void OnPathComplete(Path p)
    {
        if (!p.error) 
        {
            path = p;
            currenwaypoint = 0;
        }
    }
    void FixedUpdate()
    {
        if (target == null) 
        {
            return ;
        }

        if (path == null)
        {
            return;
        }

        if (currenwaypoint >= path.vectorPath.Count)
        {
            if (pathisend)
            {
                return;
            }

            pathisend = true;
            return;
        }

        pathisend   = false;
        float dist  = Vector3.Distance (transform.position, path.vectorPath [path.vectorPath.Count-1]);
        float dist1 = Vector3.Distance (transform.position,target.position);

        if (Math.Abs(dist - dist1) > 1)
        {
            allrightallright = true;
            return;
        }
        
        allrightallright =false;
    }
}
