using UnityEngine;
using System.Collections;

public class PrixEtageControlleur : MonoBehaviour {

    public GameObject textPrix;

	// Use this for initialization
	void Start () {
        textPrix.GetComponent<TextMesh>().text =  GameManager.instance.prixFloor.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
