using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menupause : MonoBehaviour {
	public GameObject menu;
	// Use this for initialization
	void Start () {
		menu.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void pause()
	{
        Debug.Log("menu.activeInHierarchy" + menu.activeInHierarchy);
        Debug.Log("Time.timeScale" + Time.timeScale);
        Debug.Log(" menu.activeSelf " + menu.activeSelf);
        if (menu.activeInHierarchy ==false|| Time.timeScale >0|| menu.activeSelf == false) {
			Time.timeScale = 0;
			menu.SetActive (true);
		} else {
			Time.timeScale = 1;
			menu.SetActive (false);	
		}
	}
}
