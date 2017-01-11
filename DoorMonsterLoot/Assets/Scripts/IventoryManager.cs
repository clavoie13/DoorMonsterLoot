using UnityEngine;
using System.Collections;

public class IventoryManager : MonoBehaviour {

    public static IventoryManager instance = null;

    private GameObject[] inventoryArray; 

    // Use this for initialization
    void Start () {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        inventoryArray = new GameObject[3] { null, null, null };
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addToInventory(GameObject item)
    {
        if(inventoryArray[0] == null)
        {
            inventoryArray[0] = item;
        }
        else if (inventoryArray[1] == null)
        {
            inventoryArray[1] = item;
        }
        else if (inventoryArray[2] == null)
        {
            inventoryArray[2] = item;
        }

    }

    public void removeFromInventory(int index)
    {
        inventoryArray[index] = null;
    }

    public bool isOccupe(int index)
    {
        if(inventoryArray[index] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public GameObject getItem(int index)
    {
        return inventoryArray[index];
    }

    public bool canAddItem()
    {
        if (inventoryArray[2] == null)
        {
            return true;
        }
        return false;
    }
}
