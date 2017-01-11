using UnityEngine;
using System.Collections;

public class LockKey : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

       gameObject.GetComponent<AudioSource>().Play();

       GameManager.instance.spawnRewardScreen();
    }
}
