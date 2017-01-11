using UnityEngine;
using System.Collections;

public class DDManager : MonoBehaviour {

    public float percentDMG = 0.05f;

    public GameObject[] tableauDeDoors;
    public GameObject DoorVide;
    public GameObject loot;
    public GameObject BonhommeVert;

    public GameObject ParticulePorte;


    public int difficuty = 0;

    int nbrDoorASpawner = 0;
    bool first = true;

    int winner = 0;

    // Use this for initialization
    void Start()
    {
        //SI ON VEUX UN BONUS
        /*dmgModifier = 0.15f;
        //dmgModifier = GameManager.instance.DDdmgModifier;
        percentDMG = percentDMG + (percentDMG * dmgModifier);*/

        

        //HBd1 =  door1.GetComponentInChildren<DDHealthBar>();
        
        initialiseDoors();
        setDmgToDoor();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void setDmgToDoor()
    {
        for (int i = 0; i < nbrDoorASpawner; i++)
        {
            tableauDeDoors[i].GetComponentInChildren<DDHealthBar>().setDmg(percentDMG);
        }
    }

    void getDifficulte()
    {
        //Fonction pour aller chercher la difficulte voulu
        if (GameManager.instance.floor > 3)
        {
            for (int i = 0; i < GameManager.instance.floor / 3; i++)
            {
                percentDMG *= 0.75f;
            }
        }
        difficuty = GameManager.instance.floor % 3;
    }

    void initialiseDoors()
    {
        getDifficulte();

        switch (difficuty)
        {
            //Easy
            case 1:
                nbrDoorASpawner = 2;
                break;

            //Medium 
            case 2:
                nbrDoorASpawner = 3;
                break;

            //Hard
            case 0:
                nbrDoorASpawner = 4;
                break;
        }

        for (int i = 0; i < nbrDoorASpawner; i++)
        {
            
            difficuty = Random.Range(0, 4);

            while (tableauDeDoors[difficuty].activeSelf)
            {
                difficuty = Random.Range(0, 4);
            }

            if (first)
            {
                winner = difficuty;
                first = false;
            }

            tableauDeDoors[difficuty].SetActive(true);
            tableauDeDoors[difficuty].GetComponentInChildren<DDHealthBar>().setIndexDoor(difficuty);
        }
    }

    public void DestroyDoor(int i)
    {
        Instantiate(DoorVide, tableauDeDoors[i].transform.position, Quaternion.identity);
        Instantiate(ParticulePorte, tableauDeDoors[i].transform.position, Quaternion.identity);
        tableauDeDoors[i].SetActive(false);

        if (i == winner)
        {
            Instantiate(loot, tableauDeDoors[i].transform.position - new Vector3(1.65f,2.3f,0), Quaternion.identity);

            for (int j = 0; j < tableauDeDoors.Length; j++)
            {
                tableauDeDoors[j].GetComponent<PolygonCollider2D>().enabled = false;
                //Destroy(tableauDeDoors[j].gameObject);
            }

            GameManager.instance.spawnRewardScreen();

            //UnityEngine.SceneManagement.SceneManager.LoadScene("DoorSelection");
        }
        else
        {
            Instantiate(BonhommeVert, tableauDeDoors[i].transform.position - new Vector3(0, 1.82f, 0), Quaternion.identity);
            //Perdu
        }


    }
}
