using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasersensor : MonoBehaviour {
	public GameObject turn;
	public int timer=0; 
	public int maxtimer=100; 
	private Collider2D collider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position,-1 *transform.right,5); // transform.position + (transform.right * (float)offset) can be used for casting not from center.
		if (hit) {
			collider = hit.collider;
			//Debug.Log (collider.gameObject.tag);

			if (collider.gameObject.tag == "laser") {
				turn.SetActive (true);
				timer = 0;
				Debug.Log (collider.gameObject.tag);
			}else Physics2D.IgnoreCollision (hit.collider,hit.collider);
		}
	/*	if (turn.activeSelf==true) {
			timer += 1;
			if (timer >= maxtimer) {
				timer = 0;
				turn.SetActive (false);
				return;
			}
		}*/

	}

}
