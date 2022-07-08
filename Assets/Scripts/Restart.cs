using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour 
{
	public GameObject Player;
	public GameObject viruses;
    public GameObject backinplace;
    private Rigidbody2D rb2d;
	public string tagpi;
    private Vector3 intialLocation = new Vector3(0, 0, 0);

	void Start () 
	{
		rb2d = Player.GetComponent<Rigidbody2D> ();

        if (backinplace != null)
        {
            intialLocation = backinplace.transform.position;
        }
    }

	public void RestartPlayer()
	{
		rb2d.position	= new Vector3 (0, -0.1f, 0);
		rb2d.velocity	= Vector3.zero;
		rb2d.velocity	= new Vector2(0,0);
	}

	public void RestartViruse()
	{
		foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(tagpi)) 
		{
			Destroy (laserSplit);
		}

		GameObject go			= Instantiate (viruses, gameObject.transform.position, Quaternion.Euler (0, 0, 0));
		go.name					= tagpi;
		((GameObject)go).tag	= tagpi;
		go.transform.position	= new Vector3 (34, 34, 0);
	}

    public void Restartback()
    {
        if (backinplace != null)
        {
            backinplace.transform.position = intialLocation;
        }
    }
}
