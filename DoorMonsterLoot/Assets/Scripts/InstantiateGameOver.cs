using UnityEngine;
using System.Collections;

public class InstantiateGameOver : MonoBehaviour {

    public GameObject posPanelGV;
    public GameObject panelGV;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(panelGV, posPanelGV.transform.position, Quaternion.identity);
    }
}
