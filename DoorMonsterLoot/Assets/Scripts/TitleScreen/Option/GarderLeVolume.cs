using UnityEngine;
using System.Collections;

public class GarderLeVolume : MonoBehaviour {


    public float leVolume = 0.5f;

    bool i = false;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("Volume"))
        {
            leVolume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            EnregistrerVolumeParDefault();
        }

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * leVolume;
        gameObject.GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void mettreAJourLeVolume(float volume)
    {
        if (i)
        {
            leVolume = volume;
            gameObject.GetComponent<AudioSource>().volume = 0.25f * leVolume;
        }
        else
        {
            i = true;
        }
    }

    public void EnregistrerLeVolume()
    {
        PlayerPrefs.SetFloat("Volume", leVolume);
    }

    public void EnregistrerVolumeParDefault()
    {
        leVolume = 0.5f;
        EnregistrerLeVolume();
    } 

}
