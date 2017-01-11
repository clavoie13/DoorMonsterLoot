using UnityEngine;
using System.Collections;

public class GameOverDoorsText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "" + ScoreManager.scoreDoors;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
