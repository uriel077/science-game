using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class enemyai : MonoBehaviour {
	public Transform target;
	//public Transform pistclone;
	public float updateRate=2f;

	private Seeker seeker;
	private Rigidbody2D rb;

	//calculate path
	public Path path;
	//ai speed
	public float speed=20;
	public ForceMode2D fmode;
	[HideInInspector]
	public bool pathisend = false;
	//the max distance 
	public float nextwaytodistance=3;

	private int  currenwaypoint=0;

	public string tagpi;
	public int maxpist=10;
	public int timer=0; 
	public int maxtimer=1;
	void Start(){
		
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		if (target == null) {
			GameObject[] g = GameObject.FindGameObjectsWithTag ("Player");
			target = g[0].transform;

		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		StartCoroutine(UpdatePath());
	}
	void Update(){
		timer += 1;
		if (timer >= maxtimer) {
			timer = 0;
		int numpi = 0;
		foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(tagpi)) {
			numpi++;
		}

		if (numpi < maxpist) {

			Object go = Instantiate (gameObject, gameObject.transform.position, Quaternion.Euler (0, 0, 0));
			go.name = tagpi;
			((GameObject)go).tag = tagpi;
		}

		//	return;
		}

	
	}
	IEnumerator UpdatePath(){
		//AstarPath.active.Scan ();
		if (target == null) {
			yield return false ;
		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine(UpdatePath());
	}
	public void OnPathComplete(Path p){
		//Debug.Log ("we have a path" + p.error);
		if (!p.error) {
			path = p;
			currenwaypoint = 0;
		}
	}
		void FixedUpdate(){
		if (target == null) {
			return ;
		}
		if (path == null)
			return;
		if (currenwaypoint >= path.vectorPath.Count)
		{
		if (pathisend) 
			return;
			//Debug.Log ("end of path");
			pathisend = true;
			return;
	}

		pathisend = false;
		Vector3 dir = (path.vectorPath [currenwaypoint] - transform.position).normalized;
		dir*=speed*Time.fixedDeltaTime;
		rb.AddForce (dir, fmode);
		float dist = Vector3.Distance (transform.position, path.vectorPath [currenwaypoint]);
		if (dist<nextwaytodistance){
			currenwaypoint++;
			return;

		}



	}
	public void restart(){
		foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(tagpi)) {
			Destroy (laserSplit);
		}
		Object go = Instantiate (gameObject, gameObject.transform.position, Quaternion.Euler (0, 0, 0));
		go.name = tagpi;
		((GameObject)go).tag = tagpi;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "killer") 
			Destroy (this.gameObject);
        if (coll.gameObject.tag == "bullet")
            Destroy(this.gameObject);
        

    }

}
