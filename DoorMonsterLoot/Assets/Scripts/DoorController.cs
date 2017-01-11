using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public int idDoor;
    public string nomScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        GameManager.instance.idScene = 2;
        GameManager.instance.idDoorClicked = idDoor;
        UnityEngine.SceneManagement.SceneManager.LoadScene(nomScene);
        //Application.LoadLevel(nomScene); 
    }
}
