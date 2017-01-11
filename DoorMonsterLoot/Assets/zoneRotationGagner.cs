using UnityEngine;
using System.Collections;

public class zoneRotationGagner : MonoBehaviour {

    int compteur = 0;
    public GameObject premierCoffre;
    public GameObject deuxiemeCoffre;
    public GameObject premierRotator;
    public GameObject deuxiemeRotator;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(compteur > 1)
        {
            premierCoffre.GetComponent<Rigidbody2D>().isKinematic = true;
            deuxiemeCoffre.GetComponent<Rigidbody2D>().isKinematic = true;

            premierRotator.GetComponent<CircleCollider2D>().enabled = false;
            deuxiemeRotator.GetComponent<CircleCollider2D>().enabled = false;


            GameManager.instance.spawnRewardScreen();
            compteur = -1000;

            Debug.Log("Gagner");
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        compteur++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        compteur--;
    }
}
