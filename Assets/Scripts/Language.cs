using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour 
{
	public Text ChosenOne;
	void Start()
	{
		ImTheChosenOne ();
	}

	public void ImTheChosenOne()
	{
		if (PlayerPrefs.GetString ("language") == transform.gameObject.name) 
		{
			{
				ChosenOne.color									= Color.cyan;
				gameObject.GetComponent<Button>().interactable	= false;
			}
				
		}
	}

	public void chooselanguge()
	{
		PlayerPrefs.SetString("language", transform.gameObject.name);
		Application.LoadLevel(0);
	}
}
