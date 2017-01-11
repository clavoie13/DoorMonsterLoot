using UnityEngine;
using System.Collections;

public class MusiqueGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;

        Camera.main.GetComponent<AudioSource>().Stop();

        gameObject.GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update () {
	


	}



}
