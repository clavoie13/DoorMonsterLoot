using UnityEngine;
using System.Collections;

public class ConsomerLeClique : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {

        GameManager.instance.StopTime = false;

        switch (GameManager.instance.idScene)
        {
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadScene("DoorSelection");
                break;

            case 1:
                GameManager.instance.idScene = 0;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
                break;

        }
    }
}
