using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour {
	private bool showOneTime=true;
    public static int percentToShowAd=15;
    const  string gameId = "1384766";
    // Use this for initialization
    void Start () {
        System.Random randomShowAd = new System.Random();
        //onetime = true;
        Advertisement.Initialize(gameId, true);
        if (percentToShowAd >= randomShowAd.Next(1, 101))
        {
            StartCoroutine(showAdWhenReady());
        }
        
       
    }
   
    IEnumerator showAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }
   
}
