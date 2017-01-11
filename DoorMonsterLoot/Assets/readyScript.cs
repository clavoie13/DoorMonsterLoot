using UnityEngine;
using System.Collections;

public class readyScript : MonoBehaviour {

    public GameObject text1;
    public GameObject text2;

    public GameObject stealText;

	// Use this for initialization
	void Start () {
        text1.GetComponent<TextMesh>().text = "Floor " + GameManager.instance.floor;
        text2.GetComponent<TextMesh>().text = "Floor " + GameManager.instance.floor;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void steal()
    {
        Instantiate(stealText, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
