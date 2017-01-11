using UnityEngine;
using System.Collections;

public class BoutonSave : MonoBehaviour {

    public GameObject boutonStart;
    public GameObject boutonOption;
    public GameObject panelPourLesOptions;
    public GameObject leSliderVolume;
    public GameObject pourGarderLeVolume;
    public GameObject pourJouerLeSon;


    // Use this for initialization
    void Start () {

    }


    void OnEnable()
    {
        boutonStart.SetActive(false);
        boutonOption.SetActive(false);
        leSliderVolume.SetActive(true);
    }

	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {

        pourGarderLeVolume.GetComponent<GarderLeVolume>().EnregistrerLeVolume();

        pourJouerLeSon.GetComponent<PourLeSonDesBoutons>().JouerLeSon();

        boutonStart.SetActive(true);

        boutonStart.GetComponent<Animator>().enabled = false;
        boutonStart.transform.position = new Vector2(0, 50);

        boutonOption.SetActive(true);

        boutonOption.GetComponent<Animator>().enabled = false;
        boutonOption.transform.position = new Vector2(0, 48.75f);

        panelPourLesOptions.SetActive(false);

        leSliderVolume.SetActive(false);




    }
}
