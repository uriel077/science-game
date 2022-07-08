using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour 
{
    public GameObject menu;

    // Use this for initialization
    void Start () 
    {
        menu.SetActive (false);	
    }
    
    public void pause()
    {
        if (menu.activeInHierarchy == false || Time.timeScale > 0 || menu.activeSelf == false) 
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        } 
        else 
        {
            Time.timeScale = 1;
            menu.SetActive(false);	
        }
    }
}
