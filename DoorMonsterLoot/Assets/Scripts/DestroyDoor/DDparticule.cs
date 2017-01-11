using UnityEngine;
using System.Collections;

public class DDparticule : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(getRandomFloat(), getRandomFloat()));
        gameObject.GetComponent<Rigidbody2D>().AddTorque(getRandomFloat());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    float getRandomFloat()
    {
        return Random.Range(-75, 75);
    }

}
