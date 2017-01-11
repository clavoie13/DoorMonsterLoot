using UnityEngine;
using System.Collections;

public class WorldMapManager : MonoBehaviour {

    public GameObject[] listeChateaux;

    string nomChateau;

	// Use this for initialization
	void Start () {
	    
        for(int i = 0; i < listeChateaux.Length; i++)
        {
            nomChateau = "chateau" + (i + 1).ToString() + "Unlocked";
            Debug.Log(nomChateau);
            if (PlayerPrefs.HasKey(nomChateau))
            {
                if (PlayerPrefs.GetInt(nomChateau) == 1)
                {
                    listeChateaux[i].GetComponent<CastleController>().setUnlocked(nomChateau);
                }
            }
            else
            {
                if(i == 0)
                {
                    PlayerPrefs.SetInt(nomChateau, 1);
                    listeChateaux[i].GetComponent<CastleController>().setUnlocked(nomChateau);
                }
                else
                {
                    PlayerPrefs.SetInt(nomChateau, 0);
                }
            }
        }
          
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
