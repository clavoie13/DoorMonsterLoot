using UnityEngine;
using System.Collections;

public class lesSpawner : MonoBehaviour {

    bool dejaChoisi = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool getDejaChoisi()
    {
        return dejaChoisi;
    }

    public void Choisir()
    {
        dejaChoisi = true;
    }

    public void initialiserChoisir()
    {
        dejaChoisi = false;
    }

}
