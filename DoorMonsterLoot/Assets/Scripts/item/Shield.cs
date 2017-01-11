using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public int index;
    GameObject GameManagerCombat;
    gameManagerCombat scriptGM;


    // Use this for initialization
    void Start()
    {
        if (GameManager.instance.idScene == 1)
        {
            GameManagerCombat = GameObject.FindGameObjectWithTag("GameManagerCombat");
            scriptGM = GameManagerCombat.GetComponent<gameManagerCombat>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (GameManager.instance.idScene == 1)
        {
            scriptGM.Shield();
            IventoryManager.instance.removeFromInventory(index);
            Destroy(gameObject);
        }
    }
}
