using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerOne : MonoBehaviour 
{
    const string musicPlayerName = "mainMusic";

    // Use this for initialization
    void Start () 
    {
        int numberOfMusicPlayer= 0;
      
        //loop all the music player
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "mainMusic")
            {
                numberOfMusicPlayer++;
            }
        }

        if (numberOfMusicPlayer > 1) 
        { 
            Destroy(this.gameObject); 
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
