using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * PlayerPrefs.GetFloat("Volume");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sonFocus()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
