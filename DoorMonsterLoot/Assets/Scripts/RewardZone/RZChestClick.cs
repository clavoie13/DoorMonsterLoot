using UnityEngine;
using System.Collections;

public class RZChestClick : MonoBehaviour {

    public GameObject openChest;
    public GameObject Reward;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        openChest.SetActive(true);
        
        GameObject R = (GameObject)Instantiate(Reward, gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        R.GetComponent<RZChestMoney>().GetReward();

        gameObject.SetActive(false);
    }
}
