using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;
    public static int scoreDoors = 0;

    private TextMesh text;

	// Use this for initialization
	void Start () {
        text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "" + score;
	}
}
