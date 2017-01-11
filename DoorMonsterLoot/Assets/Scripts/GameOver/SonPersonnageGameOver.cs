using UnityEngine;
using System.Collections;

public class SonPersonnageGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;

    }

    // Update is called once per frame
    void Update () {

	}

    public void JouerLeSon()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
