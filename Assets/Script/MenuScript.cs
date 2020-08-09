using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour {
	public Button startText;
	// Use this for initialization
	void Start () {
		startText = startText.GetComponent<Button>();
	}
	
	public void Startlevel()
	{
		Application.LoadLevel (1);
	}
}
