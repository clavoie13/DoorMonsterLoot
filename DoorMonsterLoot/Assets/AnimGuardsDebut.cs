using UnityEngine;
using System.Collections;

public class AnimGuardsDebut : MonoBehaviour {

    public GameObject g2;
    public GameObject g3;

    public GameObject wtf1;
    public GameObject wtf2;
    public GameObject wtf3;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartRun()
    {
        g2.GetComponent<Animator>().SetBool("Run", true);
        g3.GetComponent<Animator>().SetBool("Run", true);
        Debug.Log("Je suis ici");
    }

    public void changeMain()
    {
        Application.LoadLevel("Main");
    }

    public void activerWtf()
    {
        wtf1.SetActive(true);
        wtf2.SetActive(true);
        wtf3.SetActive(true);

    }

    public void nopeWtf()
    {
        wtf1.SetActive(false);
        wtf2.SetActive(false);
        wtf3.SetActive(false);

    }
}
