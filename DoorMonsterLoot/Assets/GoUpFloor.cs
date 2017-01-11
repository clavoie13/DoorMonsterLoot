using UnityEngine;
using System.Collections;

public class GoUpFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        GameManager.instance.StopTime = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");

        GameManager.instance.floor = GameManager.instance.floor + 1;
        GameManager.instance.setPrixFloor();
    }
}
