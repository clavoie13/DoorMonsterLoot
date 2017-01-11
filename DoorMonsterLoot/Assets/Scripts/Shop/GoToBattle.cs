using UnityEngine;
using System.Collections;

public class GoToBattle : MonoBehaviour {

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
    }
}
