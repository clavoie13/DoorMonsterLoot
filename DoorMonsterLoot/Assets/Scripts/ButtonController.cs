using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public string nomScene;

	// Use this for initialization
	void Start () {


    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * PlayerPrefs.GetFloat("Volume");

        gameObject.GetComponent<AudioSource>().Play();

        UnityEngine.SceneManagement.SceneManager.LoadScene(nomScene);
        //Application.LoadLevel(nomScene);
    }
}
