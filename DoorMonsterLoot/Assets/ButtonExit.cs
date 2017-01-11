using UnityEngine;
using System.Collections;

public class ButtonExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("InventoryManager"));
        ScoreManager.score = 0;
        ScoreManager.scoreDoors = 0;

        UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
    }
}
