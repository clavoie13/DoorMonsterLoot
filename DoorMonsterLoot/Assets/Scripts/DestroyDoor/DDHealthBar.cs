using UnityEngine;
using System.Collections;

public class DDHealthBar : MonoBehaviour {

    public GameObject barreDeVie;
    float dmg = 0.05f;
    float TotalScale;
    float calcul = 0;
    int indexDoor = 0;
    public GameObject manager;
    float health = 1.0f;
   
    // Use this for initialization
    void Start()
    {
        TotalScale = barreDeVie.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDmg(float d)
    {
        dmg = d;
    }

    public void HealthDown()
    {
        health = health - dmg;
        calcul = barreDeVie.transform.localScale.x - (TotalScale * dmg);

        if (health <= 0)
        {
            barreDeVie.transform.localScale = new Vector3(0, 0, 0);

            /* METTRE L<APPEL DU DESTROY ICI */
            manager.GetComponent<DDManager>().DestroyDoor(indexDoor);
            
        }
        else
        {
            barreDeVie.transform.localScale -= new Vector3((TotalScale * dmg), 0, 0);
        }
    }

    public void setIndexDoor(int index)
    {
        indexDoor = index;
    }
}
