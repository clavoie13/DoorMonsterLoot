using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public  GameObject[] DoorArray;

    public GameObject OpenStairs;
    int globalScore;

    public GameObject PosDoor1Object;
    public GameObject PosDoor2Object;
    public GameObject PosDoor3Object;
    public GameObject PosDoor4Object;
    public GameObject PosDoor5Object;
    public GameObject PosDoor6Object;

    public GameObject PosStairs1Object;
    public GameObject PosStairs2Object;

    public GameObject RewardScreen;
    public GameObject chest;
    GameObject[] tabChest = new GameObject[3];
    GameObject RS;


    public Vector3 PosDoor1;
    public Vector3 PosDoor2;
    public Vector3 PosDoor3;
    public Vector3 PosDoor4;
    public Vector3 PosDoor5;
    public Vector3 PosDoor6;

    public Vector3 PosStairs1;
    public Vector3 PosStairs2;

    public bool isDoorOpen1 = true;
    public bool isDoorOpen2 = true;
    public bool isDoorOpen3 = true;

    public int indexDoor1;
    public int indexDoor2;
    public int indexDoor3;

    public int idDoorClicked;

    public float currentTime;
    public float startTime = 30f;

    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    public int floor = 1;
    public int prixFloor = 0;

    public bool StopTime = true;

    public int characterDmg = 2;
    public int characterDef = 1;

    public int nbrAAvoir = 1;

    string nomChateau;

    //Variable pour savoir si on est en combat ou autre scene. Course = 0, Combat = 1, Mini-jeux = 2
    public int idScene = 0;

    //Variable pour le gameManagerCombat. On s'en sert seulment pour caller la fin quand on manque de temps
    GameObject leGameManagerCombat = null;

    //La variable qui concerve le volume choisi par le joueur
    public float volumeGeneral = 0;

    public float distanceEnd;

    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        PosDoor1 = PosDoor1Object.transform.position;
        PosDoor2 = PosDoor2Object.transform.position;
        PosDoor3 = PosDoor3Object.transform.position;
        PosDoor4 = PosDoor4Object.transform.position;
        PosDoor5 = PosDoor5Object.transform.position;
        PosDoor6 = PosDoor6Object.transform.position;

        PosStairs1 = PosStairs1Object.transform.position;
        PosStairs2 = PosStairs2Object.transform.position;

        InstantiateDoors();

        setPrixFloor();

        currentTime = 110;

        loaderLeVolume();

        distanceEnd = 1100;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InstantiateDoors()
    {
        int randomDoorIndex;

        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor1 = randomDoorIndex;

        GameObject myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor1, Quaternion.identity);
        DoorController myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 1;

        /*if(isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }*/


        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor2 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor2, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 2;

        /*if (isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }*/


        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor3 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor3, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 3;

        /*if (isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }*/
    }

    public void InstantiateNextDoors()
    {
        int randomDoorIndex;

        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor1 = randomDoorIndex;

        GameObject myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor4, Quaternion.identity);
        DoorController myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 1;

        
        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor2 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor5, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 2;


        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor3 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor6, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 3;
    }

    public void RecreateDoor()
    {
        if(idDoorClicked == 1)
        {
            isDoorOpen1 = false;
        }
        else if(idDoorClicked == 2)
        {
            isDoorOpen2 = false;
        }
        else if (idDoorClicked == 3)
        {
            isDoorOpen3 = false;
        }

        idDoorClicked = 0; 

        if(ScoreManager.score >= prixFloor)
        {
            Instantiate(OpenStairs, PosStairs1, Quaternion.identity);
            Instantiate(OpenStairs, PosStairs2, Quaternion.identity);
        }

        GameObject myDoor = (GameObject)Instantiate(DoorArray[indexDoor1], PosDoor1, Quaternion.identity);
        DoorController myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 1;

        if (isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            myDoor.GetComponent<BoxCollider2D>().enabled = false;
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }

        myDoor = (GameObject)Instantiate(DoorArray[indexDoor2], PosDoor2, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 2;

        if (isDoorOpen2)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
                
            }
        }
        else
        {
            myDoor.GetComponent<BoxCollider2D>().enabled = false;
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }

        myDoor = (GameObject)Instantiate(DoorArray[indexDoor3], PosDoor3, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 3;

        if (isDoorOpen3)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
                
            }
        }
        else
        {
            myDoor.GetComponent<BoxCollider2D>().enabled = false;
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }
    }

    public void LooseGame()
    {
        //Trouver la bonne animation a faire quand le joueur perd. 1 = combat
        switch (idScene)
        {
            case 1: //combat
                leGameManagerCombat = GameObject.FindGameObjectWithTag("GameManagerCombat");
                leGameManagerCombat.GetComponent<gameManagerCombat>().partiePerduManqueDeTemps();
                idScene = 0;
                break;
            default: //meme chose pour tous sauf pour combat
                SauvegarderProgressionPartie();
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
                Application.LoadLevel("GameOver");
                break;


        }
    }

    //section a chri
    public void spawnRewardScreen()
    {
        StopTime = true;

        RS = (GameObject)Instantiate(RewardScreen, new Vector3(0, 0, 0), Quaternion.identity);

        idScene = 0;

        Vector3[] tab = RS.GetComponent<RZManager>().getPosition();

        for (int i = 0; i < 3; i++)
        {
            tabChest[i] = (GameObject)Instantiate(chest, tab[i], Quaternion.identity);
            tabChest[i].transform.SetParent(RS.transform);
        }

        //On est dans la scene main apres avoir eu un reward

        //IL FAUT ARRETER LE TIMER

    }
 
    public void disableChest()
    {
        for (int i = 0; i < tabChest.Length; i++)
        {
            tabChest[i].GetComponentInChildren<BoxCollider2D>().enabled = false;
        }

        RS.GetComponentInChildren<BoxCollider2D>().enabled = true;
        RS.GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    //----------------------------

    void loaderLeVolume()
    {
        volumeGeneral = PlayerPrefs.GetFloat("Volume");
    }

    public void SauvegarderProgressionPartie()
    {
        globalScore = PlayerPrefs.GetInt("ScoreGlobal");
        globalScore += ScoreManager.score;

        nomChateau = PlayerPrefs.GetString("ChateauActuel");

        if (ScoreManager.score > PlayerPrefs.GetInt(nomChateau + "BestScore"))
        {
            PlayerPrefs.SetInt(nomChateau + "BestScore", ScoreManager.score);
        }

        if (floor > PlayerPrefs.GetInt(nomChateau + "BestFloor"))
        {
            PlayerPrefs.SetInt(nomChateau + "BestFloor", floor);
        }
        

        if (ScoreManager.scoreDoors > PlayerPrefs.GetInt(nomChateau + "BestDoor"))
        {
            PlayerPrefs.SetInt(nomChateau + "BestDoor", ScoreManager.scoreDoors);
        }


        PlayerPrefs.SetInt("ScoreGlobal", globalScore);
    }

    public void setPrixFloor()
    {
        prixFloor = 1000 * floor;
    }
}
