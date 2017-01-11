using UnityEngine;
using System.Collections;

public class CommencerTune : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;
        gameObject.GetComponent<AudioSource>().Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
