using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCredit : MonoBehaviour 
{
    public List<GameObject> creditsPhotos;
    public int maxTimer = 10;

    // Use this for initialization
    void Start () 
    {
        foreach (var creditPhoto in creditsPhotos)
        {
            creditPhoto.SetActive(true);
        }
    }

    // Update is called once per frame


    //if (timer >= maxtimer|| Input.touchCount > 0)

    private int temp = 1;
    void Update()
    {
        if (creditsPhotos == null|| creditsPhotos.Count == 0)
        {
            Destroy(this);
            return;
        }

        if (Input.touchCount > 0 || temp % maxTimer == 0)
        {
            creditsPhotos[(temp / maxTimer) - 1].SetActive(false);
            creditsPhotos.Remove(creditsPhotos[(temp / maxTimer) - 1]);
        }

        temp++;
        //   return;
    }
   
}
