using UnityEngine;
using System.Collections;

public class tutoController : MonoBehaviour {

    public string text;
	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
