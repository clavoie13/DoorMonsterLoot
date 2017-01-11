using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        //Application.LoadLevel(nomScene);
    }
}
