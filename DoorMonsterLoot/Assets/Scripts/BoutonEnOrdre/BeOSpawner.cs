using UnityEngine;
using System.Collections;

public class BeOSpawner : MonoBehaviour {

    bool dejaChoisi = false;

	// Use this for initialization
	void Start () {
        dejaChoisi = false;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public bool getDejaChoisi()
    {
        return dejaChoisi;
    }

    public void okChoisi()
    {
        dejaChoisi = true;
    }

    public void ReinitialiseLeChoisi()
    {
        dejaChoisi = false;
    }
}
