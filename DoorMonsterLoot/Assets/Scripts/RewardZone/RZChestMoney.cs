using UnityEngine;
using System.Collections;

public class RZChestMoney : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetReward()
    {

        int reward = RewardInChest();

        gameObject.GetComponentInChildren<TextMesh>().text = reward.ToString();

        ScoreManager.score += reward;
        ScoreManager.scoreDoors += 1;
        GameManager.instance.disableChest();
    }

    int RewardInChest()
    {
        //return 3000;
        return 100 * GameManager.instance.floor + Random.Range(-25, 101);
    }
}
