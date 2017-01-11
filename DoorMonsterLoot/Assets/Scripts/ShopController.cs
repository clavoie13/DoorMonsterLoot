using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour {

    public GameObject player;
    public GameObject[] ShopItemsArray;


    public GameObject PosItem1Object;
    public GameObject PosItem2Object;
    public GameObject PosItem3Object;

    public Vector3 PosItem1;
    public Vector3 PosItem2;
    public Vector3 PosItem3;

    GameObject vientEtreSpawner;
    int prixTemporaire = 0;


    // Use this for initialization
    void Start() {
        PosItem1 = PosItem1Object.transform.position;
        PosItem2 = PosItem2Object.transform.position;
        PosItem3 = PosItem3Object.transform.position;

        int randomDoorIndex;

        //Premier item
        randomDoorIndex = Random.Range(0, ShopItemsArray.Length);
        vientEtreSpawner = (GameObject)Instantiate(ShopItemsArray[randomDoorIndex], PosItem1, Quaternion.identity);
        envoyerLePrix(randomDoorIndex);

        //Deuxieme Item
        randomDoorIndex = Random.Range(0, ShopItemsArray.Length);
        vientEtreSpawner = (GameObject)Instantiate(ShopItemsArray[randomDoorIndex], PosItem2, Quaternion.identity);
        envoyerLePrix(randomDoorIndex);

        //Troisieme item
        randomDoorIndex = Random.Range(0, ShopItemsArray.Length);
        vientEtreSpawner = (GameObject)Instantiate(ShopItemsArray[randomDoorIndex], PosItem3, Quaternion.identity);
        envoyerLePrix(randomDoorIndex);

        vientEtreSpawner = null;

        //Ajuster le son
        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;

        player.GetComponent<PlayerController>().moveSpeed = 10;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void sonAchat()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void envoyerLePrix(int typeItem)
    {
        switch (typeItem)
        {
            //Shield
            case 0:
                prixTemporaire = 900 * GameManager.instance.floor + Random.Range((GameManager.instance.floor - 1) * 50, GameManager.instance.floor * 50);
                break;

            //Atk Up
            case 1:
                prixTemporaire = 1000 * GameManager.instance.floor + Random.Range((GameManager.instance.floor - 1) * 150, GameManager.instance.floor * 150);
                break;

            //Potion
            case 2:
                prixTemporaire = 800 * GameManager.instance.floor + Random.Range((GameManager.instance.floor - 1) * 100, GameManager.instance.floor * 100);
                break;

            default:
                prixTemporaire = 1;
                break;
        }

        vientEtreSpawner.GetComponent<ItemShopController>().setLePrix(prixTemporaire);
        prixTemporaire = 0;

    }
}
