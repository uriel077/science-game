using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour 
{
	private Transform player;
    public Vector3 positionOfTheFollowerOnThePlayer;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player").transform;
	}
	
	// follow the player
	void Update () 
	{
		Vector3 playerPos = player.position;
		if(transform.position.z != 0)
        {
			playerPos.z = transform.position.z;
		}

		transform.position = playerPos + positionOfTheFollowerOnThePlayer;
	}
}
