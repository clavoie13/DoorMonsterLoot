using UnityEngine;
using System.Collections;

public class StairController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        GameManager.instance.StopTime = true;

        GameManager.instance.distanceEnd = 1100;
        GameManager.instance.isDoorOpen1 = true;
        GameManager.instance.isDoorOpen2 = true;
        GameManager.instance.isDoorOpen3 = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");

        //Application.LoadLevel(nomScene);
    }
}
