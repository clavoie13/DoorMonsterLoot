using UnityEngine;
using System.Collections;

public class PourLeSonDesBoutons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void JouerLeSon()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        gameObject.GetComponent<AudioSource>().Play();
    }




}
