using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SIZManager : MonoBehaviour
{

    public GameObject particule;

    GameObject pBar;
    ProgressBar PBScript;

    GameObject wZone;
    SIZWinZone WZScript;

    GameObject player;
    Transform Ptrans;

    GameObject boulder;
    Transform Btrans;

    float leTempsPasser = 0;

    bool inZone = false;
    bool isPlaying = false;

    int result;

    public float x = 0.75F;
    public Vector3 transformation;

    int difficulter;

    // Use this for initialization
    void Start()
    {

        pBar = GameObject.FindGameObjectWithTag("PBar");
        PBScript = (ProgressBar)pBar.GetComponent(typeof(ProgressBar));

        //win zone
        wZone = GameObject.FindGameObjectWithTag("WinZone");
        WZScript = (SIZWinZone)wZone.GetComponent(typeof(SIZWinZone));

        player = GameObject.FindGameObjectWithTag("player");
        Ptrans = player.GetComponent<Transform>();

        boulder = GameObject.FindGameObjectWithTag("boulder");
        Btrans = boulder.GetComponent<Transform>();

        gameObject.GetComponent<AudioSource>().volume = GameManager.instance.volumeGeneral;

        getDifficulter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime * 100 >= 1f)
        {
            PBScript.SubstractTime();
            DansLaWinZone();
            playSound();
        }
    }

    public void FromButton()
    {
        PBScript.AddTime();
    }

    void DansLaWinZone()
    {

        float pourcentage;

        pourcentage = PBScript.getFillAmount();

        result = WZScript.VerifierInZone(pourcentage);

        switch (result)
        {
            case 0:
                inZone = false;
                break;
            case 1:
                inZone = true;
                transformation.x = x;
                move();
                break;
            case 2:
                inZone = true;
                transformation.x = x * 1.75F;
                move();
                break;
        }
    }

    void move()
    {
        if (Btrans.position.x < 4.25F)
        {
            Btrans.Translate(transformation * Time.deltaTime);

            Debug.Log(Time.deltaTime);

            if (leTempsPasser >= 0.5f)
            {

                leTempsPasser = 0;

                if (result == 2)
                {
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);

                }
                else
                {
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);
                }
            }
            else
            {
                leTempsPasser += Time.deltaTime;
            }
        }
        Ptrans.Translate(transformation * Time.deltaTime);
    }

    void playSound()
    {
        if (inZone)
        {
            if (!isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                isPlaying = false;
            }
        }
    }


    void getDifficulter()
    {
        difficulter = GameManager.instance.floor % 3;

        switch (difficulter)
        {
            case 1:
                x = 0.75f;
                break;
            case 2:
                x = 0.675f;
                break;
            case 0:
                x = 0.6f;
                break;
        }

    }
}
