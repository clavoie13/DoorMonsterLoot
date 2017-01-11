using UnityEngine;
using System.Collections;

public class CommencerTuneWorldMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * PlayerPrefs.GetFloat("Volume");
        gameObject.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
