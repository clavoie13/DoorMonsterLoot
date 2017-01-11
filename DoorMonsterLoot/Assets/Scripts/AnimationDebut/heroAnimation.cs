using UnityEngine;
using System.Collections;

public class heroAnimation : MonoBehaviour {

    public AudioSource explosion;
    public AudioSource saut;
    public AudioSource course;
    public GameObject wtf;

	// Use this for initialization
	void Start () {

        explosion.volume = explosion.volume * PlayerPrefs.GetFloat("Volume");
        saut.volume = saut.volume * PlayerPrefs.GetFloat("Volume");
        course.volume = course.volume * PlayerPrefs.GetFloat("Volume");



    }

    // Update is called once per frame
    void Update () {
	
	}

    public void sonExplosion()
    {
        explosion.Play();
    }

    public void sonSaut()
    {
        saut.Play();
    }

    public void sonCourse()
    {
        course.Play();
    }

    public void activerWtf()
    {
        wtf.SetActive(true);
    }

    public void nopeWtf()
    {
        wtf.SetActive(false);
    }



}
