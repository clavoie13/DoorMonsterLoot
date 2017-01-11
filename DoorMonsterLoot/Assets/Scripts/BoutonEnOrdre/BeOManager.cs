using UnityEngine;
using System.Collections;
using System;

public class BeOManager : MonoBehaviour {

    public GameObject[] leTableauDeSpawner;
    public GameObject[] leTableauDeBoutonChiffre;
    private Vector3[] leTableauDePositionDesSpawner;
    public GameObject[] leTableauDeBoutonLettre;


    //Tableau pour supprimer les bouton si jamais le joueur se trompe pendant un round;
    private GameObject[] leTableauDesBoutonSpawner;
    private int[] leTableauPriorite;

    private int[] indexeDejaFait;
    bool indexeExistant = true;

    GameObject btnQuiVientEtreSpawner;

    public int nbrDeBoutonASpawner;

    int j = 0;
    int k = 0;
    int l = 0;

    public int nbrDeRoundAFaire = 0;
    int nbrDeRoundFait = 0;

    public GameObject checkMark;
    public GameObject cross;
    public GameObject cercle;

    public GameObject[] indicateurDeRoundGagner;

    private int randomPourSavoirQuelTableauDeBoutonJeSpawn = 0;

	// Use this for initialization
	void Start () {

        nbrDeRoundFait = 0;

        DeciderCombienDeRound();

        InitialiserUnePartie();

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;
    }
	
    void InitialiserLeTableauDePosition()
    {

        foreach (GameObject go in leTableauDeSpawner)
        {
            go.GetComponent<BeOSpawner>().ReinitialiseLeChoisi();
        }

        //Boucle pour trouver les spawners a spawner du stock dessus
        for (int i = 0; i < nbrDeBoutonASpawner; i++)
        {
           //Debug.Log("i :"+i);
            j = UnityEngine.Random.Range(0, leTableauDeSpawner.Length);

            while (leTableauDeSpawner[j].GetComponent<BeOSpawner>().getDejaChoisi() == true)
            {
                j = UnityEngine.Random.Range(0, leTableauDeSpawner.Length);
            }

            leTableauDeSpawner[j].GetComponent<BeOSpawner>().okChoisi();

            leTableauDePositionDesSpawner[i] = leTableauDeSpawner[j].gameObject.transform.position;
        }
    }

    void InitialiserLeMiniJeuBoutonChiffre()
    {
        //Boncle pour trouver les bouton chiffre a spawner
        for (int i = 0; i < nbrDeBoutonASpawner; i++)
        {

            while (indexeExistant == true)
            {
                indexeExistant = false;
                k = UnityEngine.Random.Range(0, leTableauDeBoutonChiffre.Length);

                for (int c = 0; c < i; c++)
                {
                    if (indexeDejaFait[c] == k)
                    {
                        indexeExistant = true;
                    }
                }
            }

            indexeExistant = true;

            btnQuiVientEtreSpawner = (GameObject) Instantiate(leTableauDeBoutonChiffre[k].gameObject, leTableauDePositionDesSpawner[i], Quaternion.identity);

            leTableauPriorite[i] = btnQuiVientEtreSpawner.GetComponent<BeOBouton>().getPriorite();

            indexeDejaFait[i] = k;

            leTableauDesBoutonSpawner[i] = btnQuiVientEtreSpawner;
        }

        //Supprimer les boutons qui ne sont pu bon 
        for (int i = 0; i < indexeDejaFait.Length; i++)
        {
            //Valeur trop grosse pour un indexe de bouton
            indexeDejaFait[i] = 999;
        }

        Array.Sort(leTableauPriorite);
    }

    void InitialiserLeMinuJeuBoutonLettre()
    {
        //Boncle pour trouver les bouton chiffre a spawner
        for (int i = 0; i < nbrDeBoutonASpawner; i++)
        {
            while (indexeExistant == true)
            {
                indexeExistant = false;
                k = UnityEngine.Random.Range(0, leTableauDeBoutonLettre.Length);

                for (int c = 0; c < i; c++)
                {
                    if (indexeDejaFait[c] == k)
                    {
                        indexeExistant = true;
                    }
                }
            }

            indexeExistant = true;

            btnQuiVientEtreSpawner = (GameObject)Instantiate(leTableauDeBoutonLettre[k].gameObject, leTableauDePositionDesSpawner[i], Quaternion.identity);

            leTableauPriorite[i] = btnQuiVientEtreSpawner.GetComponent<BeOBouton>().getPriorite();

            indexeDejaFait[i] = k;

            leTableauDesBoutonSpawner[i] = btnQuiVientEtreSpawner;
        }

        //Supprimer les boutons qui ne sont pu bon 
        for (int i = 0; i < indexeDejaFait.Length; i++)
        {
            //Valeur trop grosse pour un indexe de bouton
            indexeDejaFait[i] = 999;
        }

        Array.Sort(leTableauPriorite);
    }

    //Fonction qui va etre appaler dans le mouse donw du bouton et qui verifira si on est prioritaire et on se detruit ou pas selon le bool renvoiyer
    public bool BoutonClicker(int maPriorite)
    {
        //Si je suis la priorite
        if(maPriorite == leTableauPriorite[l])
        {
            l++;

            if(l == nbrDeBoutonASpawner)
            {
                Debug.Log("Win Round");

                nbrDeRoundFait++;
                cercle.SetActive(true);
                ajouterRoundGagner();

                if (nbrDeRoundFait >= nbrDeRoundAFaire)
                {
                    //Ici on fait spawner les tresors
                    Debug.Log("Win la game!!!");
                    GameManager.instance.spawnRewardScreen();
                }
                else
                {
                    InitialiserUnePartie();

                }
            }
            else
            {
                gameObject.GetComponent<AudioSource>().Play();

            }



            return true;
        }

        return false;
    }

    void InitialiserUnePartie()
    {

        //Avoir un nbr de bouton selon la difficulte

        if (GameManager.instance.floor <= 2)
        {
            nbrDeBoutonASpawner = UnityEngine.Random.Range(4, 8);
        }
        else
        {
            if (GameManager.instance.floor > 2 && GameManager.instance.floor < 5)
            {
                nbrDeBoutonASpawner = UnityEngine.Random.Range(7, 11);
            }

            else
            {
                nbrDeBoutonASpawner = UnityEngine.Random.Range(9, 14);
            }
        }

        leTableauDePositionDesSpawner = new Vector3[nbrDeBoutonASpawner];
        leTableauPriorite = new int[nbrDeBoutonASpawner];
        indexeDejaFait = new int[nbrDeBoutonASpawner];
        leTableauDesBoutonSpawner = new GameObject[nbrDeBoutonASpawner];

        j = 0;
        k = 0;
        l = 0;

        //Faire Spawner les boutons
        InitialiserLeTableauDePosition();


        if (GameManager.instance.floor < 2)
        {
            InitialiserLeMiniJeuBoutonChiffre();
        }
        else
        {
            randomPourSavoirQuelTableauDeBoutonJeSpawn = UnityEngine.Random.Range(0, 2);

            switch (randomPourSavoirQuelTableauDeBoutonJeSpawn)
            {
                case 0:
                    InitialiserLeMiniJeuBoutonChiffre();
                    break;
                case 1:
                    InitialiserLeMinuJeuBoutonLettre();
                    break;
                default:
                    InitialiserLeMiniJeuBoutonChiffre();
                    break;
            }
        }
    }

    //Fonction qui regardera combien de round on veut faire gagner au joueur (selon le nombre d'etage complete
    void DeciderCombienDeRound()
    {
        if (GameManager.instance.floor <= 2)
        {
            nbrDeRoundAFaire = 2;
        }
        else
        {
            if(GameManager.instance.floor > 2 && GameManager.instance.floor < 5)
            {
                nbrDeRoundAFaire = 3;
            }
            
            else
            {
                nbrDeRoundAFaire = 4;
            }
        }

        //Activer les cercle conteur de round
        for(int i = 0; i < nbrDeRoundAFaire; i++)
        {
            indicateurDeRoundGagner[i].gameObject.SetActive(true);
        }
    }

    public void leJoueurAFaitUneFaute()
    {
        Debug.Log("Le joueur a fait une faute");
        if (nbrDeRoundFait > 0)
        {
            nbrDeRoundFait--;
            perdreRoundGanger();
        }

        //Supprimer les boutons qui ne sont pu bon 
        foreach (GameObject go in leTableauDesBoutonSpawner)
        {
            Destroy(go);
        }

        cross.SetActive(true);

        InitialiserUnePartie();
    }

    public void bonChoix(Vector3 positionDuBouton)
    {
        Instantiate(checkMark, positionDuBouton, Quaternion.identity);
    }

    public void ajouterRoundGagner()
    {
        Debug.Log("nbr de round ganger :" + nbrDeRoundFait);
        for (int i = 0; i < nbrDeRoundFait; i++)
        {
            Debug.Log("Ajoute un round");
            indicateurDeRoundGagner[i].GetComponent<Animator>().SetBool("roundGagner", true);
        }
    }

    public void perdreRoundGanger()
    {
        indicateurDeRoundGagner[nbrDeRoundFait].GetComponent<Animator>().SetBool("roundGagner", false);
    }
}


