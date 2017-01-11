using UnityEngine;
using System.Collections;

public class SIZParticule : MonoBehaviour {

    void Start()
    {

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-25, -1), Random.Range(5, 20)));
        gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(5, 100));
    }

    // Update is called once per frame
    void Update()
    {

    }

}
