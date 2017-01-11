using UnityEngine;
using System.Collections;

public class monstre1 : MonoBehaviour {

    //Contient tout les informations sur le boss (Vie, attaque  deffence, etc, et les différentes "State"(Animation))

    public GameObject leGameManagerCombat;

    public GameObject PrefabDuShield;

    gameManagerCombat gameManagerCombatScript;

    public BoxCollider2D maBoxCollider;
    public Animator monAnimator;

    //Variable qui contient les degat d'un attaque du joueur
    int attaqueJoueur;

    //Les differents attribut du monstre
    /************************************************/
    public float vieMaximum = 250;
    public float vieCourante = 0;
    private float vieAEnvoyer = 0;
    public int defense = 1;
    public float tempsEntreChaqueState = 5;
    public float tempsAccumule = 0;
    public int idState = 0;
    public int attaqueDuMonstre = 0;
    /************************************************/

    //Les variables pour les differents projectiles du monstre 1
    /************************************************/
    public GameObject leProjectile = null;
    public GameObject[] listeProjectile;
    private bool UneAttaqueEstPrete = false; //Bool pour savoir si le monstre es entrain de faire (caster) une attaques
    private float alphaPourFeedBackAttaque = 0;
    public int sensProjectile = 0;

    /************************************************/

    //Les variable pour la healthBar
    /************************************************/
    public GameObject maHealthBar;
    public HealthBarMonstreController HealthBarMonstreControllerScript;
    /************************************************/

    bool jeSuisMort = false;
    


    
    // Use this for initialization
    void Start () {

        jeSuisMort = false;

        leGameManagerCombat = GameObject.FindGameObjectWithTag("GameManagerCombat");

        //Fait une reference sur le script du gameManagerCombat pour acceder a des fonctions
        gameManagerCombatScript = leGameManagerCombat.GetComponent<gameManagerCombat>();

        //Aller chercher son boxCollider
        maBoxCollider = gameObject.GetComponent<BoxCollider2D>();

        //Aller chercher mon animator
        monAnimator = GetComponent<Animator>();

        //Pour le moment dans la state de transition on veut desactiver le boxCollider2D
        maBoxCollider.enabled = false;

        //Initialiser les stats du monstre
        initialiserStatDuMonstre();

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;

    }
	
	// Update is called once per frame
	void Update () {


            if (gameManagerCombatScript.personnageMort == false)
            {

                //Initialisation de la healthBar pour le monstre
                HealthBarMonstreControllerScript = maHealthBar.GetComponent<HealthBarMonstreController>();

                HealthBarMonstreControllerScript.UpdateMaHealthBar(vieCourante, vieMaximum);




                //Ici dans le update on va avoir un timer qui va faire changer de state le monstre
                tempsAccumule = tempsAccumule + (Time.deltaTime);

                //Si j'ai un attaque de prete (en cours) alors la faire changer de couleur pour donne du feed back (c'est l'alpha pour le moment)
                if (UneAttaqueEstPrete == true)
                {
                    alphaPourFeedBackAttaque = tempsAccumule / tempsEntreChaqueState;
                    //leProjectile.GetComponent<SpriteRenderer>().color = new Color(1- colorPourFeedBackAttaque, 1 - colorPourFeedBackAttaque, 1 - colorPourFeedBackAttaque);
                    leProjectile.GetComponent<SpriteRenderer>().color = new Color(alphaPourFeedBackAttaque, alphaPourFeedBackAttaque, alphaPourFeedBackAttaque, alphaPourFeedBackAttaque);
                }

                if (tempsAccumule >= tempsEntreChaqueState)
                {
                    tempsAccumule = 0;

                    //Je verifie si je ne suis pas en transition (Si transition alors on fait une nouvelle animation, sinon on veux faire l'animation d'attaque et ensuite faire la transition)
                    if (idState == 0)
                    {
                        //Change de state
                        //On fait un random pour trouver dans quel state je vais etre
                        idState = Random.Range(1, 4);


                        switch (idState)
                        {
                            case 1:
                                State1();
                                break;

                            case 2:
                                State2();
                                break;

                            case 3:
                                State3();
                                break;
                            case 4:
                                State4();
                                break;
                        }
                    }

                    else
                    {
                        //Je dois faire la bonne animation pour revenir a ma state normale

                        switch (idState)
                        {
                            case 1:
                                Debug.Log("J'etais dans la state 1");
                                animationTransitionAtkUp();
                                break;

                            case 2:
                                Debug.Log("J'etais dans la state 2");
                                animationTransitionAtkCenter();
                                break;

                            case 3:
                                Debug.Log("J'etais dans la state 3");
                                animationTransitionAtkDown();
                                break;
                        }


                        if(idState != 4)
                        {
                            idState = 0;
                            State0();
                        }
                        else
                        {
                            State4();
                        }


                    }
                }
            }

            else
            {
                //Le personnage est mort alors on boucle l'animation du idle
                animationIdle();
            }
        

	}


    public void State0()
    {
        //  Debug.Log("State : 0");

        //monAnimator.SetInteger("idState", 0);

        tempsEntreChaqueState = DeciderCombienDeTempsEntreChaqueState(); //ICICICICICICIC fonction a chancger selon le code d'antoine sur la vie

        //Le monstre n'est pas touchable par le joueur pendant qu'il est dans la state 0
        maBoxCollider.enabled = false;
        PrefabDuShield.SetActive(true);

        if (UneAttaqueEstPrete == true)
        {
            leProjectile.GetComponent<projectile>().gogogo = true;
            leProjectile.GetComponent<projectile>().sens = sensProjectile;

            UneAttaqueEstPrete = false;
        }
    }

    public void State1()
    {
         Debug.Log("State : 1");

        monAnimator.SetInteger("idState", 1);

        tempsEntreChaqueState = DeciderCombienDeTempsEntreChaqueState(); //ICICICICIC Changer la focntoin pour quelle fonctionne avec la vie d'antoine

        //Ici j'avais le code pour changer la position du collider selon la state

        //Reactiver le boxCollider2D
        PrefabDuShield.SetActive(false);
        maBoxCollider.enabled = true;

        if (UneAttaqueEstPrete == false)
        {
            //Instantiate le projectIle
            leProjectile = (GameObject) Instantiate(listeProjectile[1], new Vector2(gameObject.transform.position.x - 8.5f, gameObject.transform.position.y + 4), Quaternion.Euler(0,0,90));

            UneAttaqueEstPrete = true;
            sensProjectile = 2;
        }
    }

    public void State2()
    {
         Debug.Log("State : 2");

        monAnimator.SetInteger("idState", 2);

        tempsEntreChaqueState = DeciderCombienDeTempsEntreChaqueState(); //ICICICICIC Changer la focntoin pour quelle fonctionne avec la vie d'antoine

        //Ici j'avais le code pour changer la position du collider selon la state

        //Reactiver le boxCollider2D
        PrefabDuShield.SetActive(false);
        maBoxCollider.enabled = true;

        if (UneAttaqueEstPrete == false)
        {
            //Instantiate le projectIle
            leProjectile = (GameObject) Instantiate(listeProjectile[2], new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y - 0.15f), Quaternion.identity);

            sensProjectile = 1;
            UneAttaqueEstPrete = true;
        }
    }

    public void State3()
    {
        Debug.Log("State : 3");

        monAnimator.SetInteger("idState", 3);

        //Ici j'avais le code pour changer la position du collider selon la state

        //Reactiver le boxCollider2D
        PrefabDuShield.SetActive(false);
        maBoxCollider.enabled = true;

        if (UneAttaqueEstPrete == false)
        {
            //Instantiate le projectIle
            leProjectile = (GameObject) Instantiate(listeProjectile[0], new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y - 1.5f), Quaternion.identity);

            UneAttaqueEstPrete = true;
            sensProjectile = 1;
        }
    }

    //State mort
    public void State4()
    {
        PrefabDuShield.SetActive(false);
        maBoxCollider.enabled = false;
        UneAttaqueEstPrete = false;
    }

    void OnMouseDown()
    {
        //Debug.Log("Monstre1 OnMouseDown");

        //Call de fonction pour aller calculer mes points de vie restant (Fonction int) selon les int je peux changer ma "state")
        attaqueJoueur = gameManagerCombatScript.leJoueurABlesserLeMonstre() - defense;

        gameObject.GetComponent<AudioSource>().Play();

        if (attaqueJoueur < 1)
        {
            //Il faut reflechir a ce cas
        }
        else
        {

            vieCourante = vieCourante - attaqueJoueur;

            if(vieCourante < 0)
            {
                vieCourante = 0;
            }
            //Ajuster la bar de vie du monstre


            HealthBarMonstreControllerScript.UpdateMaHealthBar(vieCourante, vieMaximum);

            //Si le monstre est mort
            if (vieCourante == 0)
            {
                idState = 4;
                jeSuisMort = true;
                UneAttaqueEstPrete = false;
                Destroy(GameObject.FindGameObjectWithTag("Projectile"));
                PrefabDuShield.SetActive(false);
                animationMort();
               
            }
           
        }
    }

    public void mort()
    {
        
        gameManagerCombatScript.leMonstreEstMort();
    }

    //CETTE FONCTION NE MARCHE PAS AVEC LE CAODE D'ANTOINE, je dois savoir si il y a maniere de savoir c'est quoi la vie courante du monstre avec le system de vie a antoine
    //
    //Fonction appeler par les differentes state pour savoir combien de temps avant de passer a la prochaine state. Pourquoi elle est appaler dans chaque state ? Plus tard je pourrais lui passer en parametre dans quel state je suis.
    public int DeciderCombienDeTempsEntreChaqueState()
    {
        //Variable avec une valeur de base si jamais on a un probleme avec les if
        int tempsARetourner = 10;

        //Si le monstre a 70% de sa vie maximum
        if ((vieCourante * 100) / vieMaximum >= 70)
        {
            //  Debug.Log("Entre 70% et 100% de vie");
            tempsARetourner = 5;
        }

        else
        {
            //Si le monstre lui reste entre 70% et 50% de sa vie maximum
            if ((vieCourante * 100) / vieMaximum >= 50)
            {
                // Debug.Log("Entre 50% et 70% de vie");
                tempsARetourner = 4;
            }

            else
            {
                //Si le monstre lui reste entre 30% et 50% de sa vie maximum
                if ((vieCourante * 100) / vieMaximum >= 30)
                {
                    //   Debug.Log("Entre 30% et 50% de vie");
                    tempsARetourner = 3;
                }

                else
                {

                    //Si le monstre lui reste entre 1% et 30% de sa vie maximum
                    if ((vieCourante * 100) / vieMaximum > 0)
                    {
                        //   Debug.Log("Entre 1% et 30% de vie");
                        tempsARetourner = 2;
                    }

                    else
                    {
                        //Le monstre est mort (ne devrait jamais aller dans se cas la.
                        tempsARetourner = 100;
                    }
                }
            }
        }
        return tempsARetourner;
    }

    void initialiserStatDuMonstre()
    {
        //Selon l'etage, le monstre a plus de vie      
        vieMaximum = 50 + (GameManager.instance.floor * Random.Range(1, 20));

        //Affecter la valeur de la variable de la vie courant
        vieCourante = vieMaximum;

        attaqueDuMonstre = 25 + (GameManager.instance.floor * Random.Range(1, 5));
    }

    public void animationIdle()
    {
        monAnimator.SetInteger("idState", 0);
    }

    public void animationTransitionAtkUp()
    {
        monAnimator.SetInteger("idState", 4);
    }

    public void animationBoucleAtkUp()
    {
        monAnimator.SetInteger("idState", 5);
    }

    public void animationTransitionAtkDown()
    {
        monAnimator.SetInteger("idState", 6);
    }

    public void animationBoucleAtkDown()
    {
        monAnimator.SetInteger("idState", 7);
    }

    public void animationTransitionAtkCenter()
    {
        monAnimator.SetInteger("idState", 8);
    }

    public void animationBoucleAtkCenter()
    {
        monAnimator.SetInteger("idState", 9);
    }

    public void animationMort()
    {
        monAnimator.SetTrigger("New Trigger");
        //monAnimator.SetInteger("idState", 10);
        PrefabDuShield.SetActive(false);
    }
}


