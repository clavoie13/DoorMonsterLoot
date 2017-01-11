using UnityEngine;
using System.Collections;

public class SIZWinZone : MonoBehaviour {

    RectTransform rect;
    public float x = 0;
    public float y = 0;

	// Use this for initialization
	void Start () {
        rect = gameObject.GetComponent<RectTransform>();
        ChoosePosition();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChoosePosition()
    {
        x = Random.Range(-271, 271);
        rect.localPosition = new  Vector2(x, y);
    }

    public int VerifierInZone(float pourcentage)
    {
        //verifier si le pourcentage se situe dans la zone 

        float borneX = 0;
        float borneY = 0;

        //x + la moitier de la zone jaune (complete)
        borneX = (x - 60 + 421)/842;
        borneY = (x + 60 + 421)/842;


        if(pourcentage >= borneX && pourcentage <= borneY)
        {
            //x + la moitier de la zone verte
            borneX = (x - 20 + 421)/842;
            borneY = (x + 20 + 421)/842;
            if (pourcentage >= borneX && pourcentage <= borneY)
            {
                return 2;
            }
            return 1;
        }
        return 0;
    }
}
