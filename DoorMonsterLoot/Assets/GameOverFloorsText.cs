using UnityEngine;
using System.Collections;

public class GameOverFloorsText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "" + GameManager.instance.floor;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
