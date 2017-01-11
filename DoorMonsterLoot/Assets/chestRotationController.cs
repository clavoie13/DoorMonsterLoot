using UnityEngine;
using System.Collections;

public class chestRotationController : MonoBehaviour {

    public GameObject green;
    public AudioSource sonOui;
    public AudioSource sonNon;

    // Use this for initialization
    void Start () {

      
        sonOui.volume = sonOui.volume * GameManager.instance.volumeGeneral;
        sonNon.volume = sonNon.volume * GameManager.instance.volumeGeneral;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        sonOui.Play();
        green.SetActive(true);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        sonNon.Play();
        green.SetActive(false);

    }
}
