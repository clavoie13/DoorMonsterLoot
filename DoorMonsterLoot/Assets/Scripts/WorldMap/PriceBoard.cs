using UnityEngine;
using System.Collections;

public class PriceBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.orthographicSize > 4.95)
        {
            gameObject.SetActive(false);
        }
    }
}
