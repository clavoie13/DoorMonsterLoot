using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonOption : MonoBehaviour {

    public GameObject panelPourLesOptions;
    public GameObject leSliderVolume;
    public GameObject pourJouerLeSon;    

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {

     }


    void OnMouseDown()
    {

        pourJouerLeSon.GetComponent<PourLeSonDesBoutons>().JouerLeSon();

        panelPourLesOptions.SetActive(true);
        leSliderVolume.SetActive(true);

        leSliderVolume.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
    }
}
