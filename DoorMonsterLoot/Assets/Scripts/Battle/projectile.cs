using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour
{


    public bool gogogo = false;
    public int sens = 0;
    public int dommageSiLeJoueurEstTouche = 0;
    bool jouerSon = false;
    public float vitesseProjectile = 15;
    //public monstre1 scriptDuMonstre;

    // Use this for initialization
    void Start()
    {

        setValeurDommage();

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;


    }

    // Update is called once per frame
    void Update()
    {

        if (gogogo == true)
        {
            if (jouerSon == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
                jouerSon = true;
            }

            if (sens == 1)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - Time.deltaTime * vitesseProjectile, gameObject.transform.position.y);
            }
            else
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - Time.deltaTime * vitesseProjectile);
            }
        }

        if (gameObject.transform.position.x <= -15 || gameObject.transform.position.y <= -10)
        {
            Debug.Log("Je suis deleter" + Time.time);
            Destroy(gameObject);
        }
    }

    public int retournerValeurDeDommage()
    {
        return dommageSiLeJoueurEstTouche;
    }

    public void setValeurDommage()
    {
        dommageSiLeJoueurEstTouche = GameObject.FindGameObjectWithTag("Monstre").GetComponent<monstre1>().attaqueDuMonstre;
        Debug.Log("Atk du monstre :" + dommageSiLeJoueurEstTouche);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ShieldItemFeedBack")
        {
            Destroy(this.gameObject);
        }
    }
}
