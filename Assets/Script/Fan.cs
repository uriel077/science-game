using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
	public int timer=0; 
	public int maxtimer=100; 
	public GameObject wind;
	
	// Update is called once per frame
	void Update ()
	{
		
		if (gameObject.activeInHierarchy == true) {
			timer += 1;
			if (timer >= maxtimer) {
				timer = 0;
				Instantiate (wind, transform.position, Quaternion.Euler (0, 0, 0));
				return;
			}
		}
	}
}
