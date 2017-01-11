using UnityEngine;
using System.Collections;

public class BeOBouton : MonoBehaviour
{

    //Variable qui permet de connaitre la priorite de ce bouton
    public int priorite = 1;

    BeOManager leScriptBeOManager;

    bool dejaChoisi = false;

    // Use this for initialization
    void Start()
    {
        dejaChoisi = false;

        leScriptBeOManager = GameObject.FindGameObjectWithTag("GameManagerBeO").GetComponent<BeOManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getDejaChoisi()
    {
        return dejaChoisi;
    }

    public void okChoisi()
    {
        dejaChoisi = true;
    }

    public int getPriorite()
    {
        return priorite;
    }

    void OnMouseDown()
    {

        if(leScriptBeOManager.BoutonClicker(priorite) == true)
        {
            //Je me detruis
            leScriptBeOManager.bonChoix(transform.position);
            gameObject.SetActive(false);

        }
        else
        {
            //Je fais un son de mauvais
            leScriptBeOManager.leJoueurAFaitUneFaute();

        }
    }

}
