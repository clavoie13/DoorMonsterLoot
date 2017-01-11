using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonDefault : MonoBehaviour {

    public GameObject pourGarderLeVolume;
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


       pourGarderLeVolume.GetComponent<GarderLeVolume>().EnregistrerVolumeParDefault();
       leSliderVolume.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");

       pourJouerLeSon.GetComponent<PourLeSonDesBoutons>().JouerLeSon();


    }
}
