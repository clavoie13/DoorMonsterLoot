using UnityEngine;
using System.Collections;

public class TestMiniJeu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        ScoreManager.score += 100;
        ScoreManager.scoreDoors += 1;

        UnityEngine.SceneManagement.SceneManager.LoadScene("DoorSelection");
        //Application.LoadLevel(nomScene);
    }
}
