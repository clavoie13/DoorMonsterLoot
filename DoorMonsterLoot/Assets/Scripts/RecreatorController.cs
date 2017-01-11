using UnityEngine;
using System.Collections;

public class RecreatorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.RecreateDoor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
