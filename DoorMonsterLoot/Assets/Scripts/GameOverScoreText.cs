using UnityEngine;
using System.Collections;

public class GameOverScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "" + ScoreManager.score;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
