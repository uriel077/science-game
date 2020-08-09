using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class arraybutton : MonoBehaviour {
//	public Button[] arr;

	// Use this for initialization
	void Start () {
        if (this.gameObject.name == "endlesslevel") {
            if (PlayerPrefs.GetString("levelpass" + 28) != "1") {
                this.gameObject.SetActive(false);
            }
        }
        else
        if (PlayerPrefs.GetString("levelpass" + int.Parse(this.gameObject.name) ) != "1"&& int.Parse(this.gameObject.name) != 1) {
            this.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setNewScene(){
		//Debug.Log (this.gameObject.name);
		Application.LoadLevel (Application.loadedLevel + int.Parse(this.gameObject.name)+1);

}
	public void setNewSceneendless(){
		//Debug.Log (this.gameObject.name);
		Application.LoadLevel (Application.loadedLevel +1);

	}
	public void nextScene(){
		//Debug.Log (this.gameObject.name);
		Application.LoadLevel (Application.loadedLevel +1);

	}
	public void pervScene(){
		//Debug.Log (this.gameObject.name);
		Application.LoadLevel (Application.loadedLevel -1);

	}
	public void levelmenueScene(){
		//Debug.Log (this.gameObject.name);
		Application.LoadLevel (1);

	}
}
