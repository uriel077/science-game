using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ArrayButton : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
        if (this.gameObject.name == "endlesslevel") 
		{
            if (PlayerPrefs.GetString("levelpass" + 28) != "1") 
			{
                this.gameObject.SetActive(false);
            }
        }
        else if (PlayerPrefs.GetString("levelpass" + int.Parse(this.gameObject.name)) != "1" && int.Parse(this.gameObject.name) != 1) 
		{
            this.gameObject.SetActive(false);
        }
	}

	public void setNewScene()
	{
		Application.LoadLevel(Application.loadedLevel + int.Parse(this.gameObject.name) + 1);
	}

	public void setNewSceneendless()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void nextScene()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void pervScene()
	{
		Application.LoadLevel(Application.loadedLevel - 1);
	}

	public void levelmenueScene()
	{
		Application.LoadLevel(1);
	}
}
