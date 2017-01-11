using UnityEngine;
using System.Collections;

public class ControlleurBoutonPause : MonoBehaviour {

    bool canReturn = false;
    public GameObject SpritePause;
    public GameObject SpriteReturn;

	// Use this for initialization
	void Start () {
	
        if(GameManager.instance.idScene == 2)
        {
            canReturn = true;
            SpriteReturn.SetActive(true);
            SpritePause.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(canReturn)
        {
            GameManager.instance.idScene = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("DoorSelection");
        }
    }
}
