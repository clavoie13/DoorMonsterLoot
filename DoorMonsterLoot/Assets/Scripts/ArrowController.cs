using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

    public GameObject Player;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseDown()
    {
        if(GameManager.instance.distanceEnd <= 0)
        {
            Application.LoadLevel("GameOver");
        }
        else
        {
            PlayerController other = (PlayerController)Player.GetComponent<PlayerController>();
            other.StartRunning();

            Destroy(gameObject);

            GameManager.instance.InstantiateNextDoors();

            GameManager.instance.isDoorOpen1 = true;
            GameManager.instance.isDoorOpen2 = true;
            GameManager.instance.isDoorOpen3 = true;

            BarDeTempsController.StartAddTime();
        }
    }
}
