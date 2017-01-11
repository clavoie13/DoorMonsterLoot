using UnityEngine;
using System.Collections;

public class FeedbackAttackUp : MonoBehaviour {

    public GameObject barreDeVie;
    float TotalScale;
    float ScaleAEnlever;
    public float nbSecondeBuff;
    GameObject GameManagerCombat;
    gameManagerCombat scriptGM;

    // Use this for initialization
    void Start () {

        GameManagerCombat = GameObject.FindGameObjectWithTag("GameManagerCombat");
        scriptGM = GameManagerCombat.GetComponent<gameManagerCombat>();

        TotalScale = barreDeVie.transform.localScale.x;
        ScaleAEnlever = (TotalScale * Time.deltaTime) / nbSecondeBuff;


        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;
        gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        barreDeVie.transform.localScale -= new Vector3((ScaleAEnlever), 0, 0);
        if(barreDeVie.transform.localScale.x <= 0)
        {
            scriptGM.AttackDown();
            Destroy(gameObject);
        }
    }
}
