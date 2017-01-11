using UnityEngine;
using System.Collections;

public class TapZones : MonoBehaviour {

    public GameObject Man;
    SIZManager manager;

    // Use this for initialization
    void Start()
    {
        Man = GameObject.FindGameObjectWithTag("Manager");
        manager = (SIZManager)Man.GetComponent(typeof(SIZManager));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
        manager.FromButton();
    }
}
