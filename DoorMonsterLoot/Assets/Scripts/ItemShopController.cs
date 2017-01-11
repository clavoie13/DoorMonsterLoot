using UnityEngine;
using System.Collections;

public class ItemShopController : MonoBehaviour {

    public int prix;
    public GameObject item;
    public GameObject shopManager;

	// Use this for initialization
	void Start () {

        GetComponent<TextMesh>().text = "" + prix + " $";

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;

        shopManager = GameObject.FindGameObjectWithTag("ShopManager");

    }

    // Update is called once per frame
    void Update () {
	    
	}

    void OnMouseDown()
    {
        if (IventoryManager.instance.canAddItem())
        {
            if (ScoreManager.score >= prix)
            {
                ScoreManager.score -= prix;
                IventoryManager.instance.addToInventory(item);

                shopManager.GetComponent<ShopController>().sonAchat();

                Destroy(gameObject);

            }
            else
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void setLePrix(int lePrixRecu)
    {
        prix = lePrixRecu;
    }
}
