using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BarDeTempsController : MonoBehaviour {

    public GameObject barreDeTemps;
    public GameObject guard;
    public static bool addingTime = false;

    // Use this for initialization

    void Awake()
    {
        
    }

    void Start () {
        barreDeTemps.transform.localScale = new Vector2((15 * GameManager.instance.currentTime) / GameManager.instance.startTime, 1);
        guard.transform.localPosition = new Vector2(6f - (11.5f * GameManager.instance.currentTime) / GameManager.instance.startTime, 3.6f);
    }

    public static void StartAddTime()
    {
        addingTime = true;
    }

    public static void StartLooseTime()
    {
        addingTime = false;
    }

    // Update is called once per frame
    void Update () {

        transform.position = new Vector2(Camera.main.transform.position.x, transform.position.y);

        if (!GameManager.instance.StopTime)
        {
            if (addingTime)
            {
                GameManager.instance.currentTime += Time.deltaTime * 5;

                if(GameManager.instance.currentTime > GameManager.instance.startTime)
                {
                    GameManager.instance.currentTime = GameManager.instance.startTime;
                }

                if (GameManager.instance.currentTime < GameManager.instance.startTime)
                {
                    barreDeTemps.transform.localScale += new Vector3((15 * (Time.deltaTime * 5)) / GameManager.instance.startTime, 0, 0);
                    guard.transform.position -= new Vector3(((11.5f * Camera.main.transform.localScale.x) * (Time.deltaTime * 5)) / GameManager.instance.startTime, 0, 0);
                }
            }
            else
            {
                barreDeTemps.transform.localScale -= new Vector3((15 * Time.deltaTime) / GameManager.instance.startTime, 0, 0);
                guard.transform.position += new Vector3((11.5f * Time.deltaTime) / GameManager.instance.startTime, 0, 0);

                GameManager.instance.currentTime -= Time.deltaTime;

                if (GameManager.instance.currentTime < 0.1)
                {
                    GameManager.instance.LooseGame();
                    Destroy(gameObject);
                }
            }
        }
	}
}
