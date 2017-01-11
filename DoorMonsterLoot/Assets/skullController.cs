using UnityEngine;
using System.Collections;

public class skullController : MonoBehaviour {

    public GameObject text1;
    public GameObject text2;

    private float distanceStart;

    // Use this for initialization
    void Start() {
        text1.GetComponent<TextMesh>().text = "" + (int)GameManager.instance.distanceEnd + "m";
        text2.GetComponent<TextMesh>().text = "" + (int)GameManager.instance.distanceEnd + "m";

        StartCoroutine(WaitAndPrint());

        distanceStart = GameManager.instance.distanceEnd;
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        GameManager.instance.distanceEnd = GameManager.instance.distanceEnd - (Time.deltaTime * 50);

        if(GameManager.instance.distanceEnd < distanceStart - 100)
        {
            GameManager.instance.distanceEnd = distanceStart - 100;
        }

        text1.GetComponent<TextMesh>().text = "" + (int)GameManager.instance.distanceEnd + "m";
        text2.GetComponent<TextMesh>().text = "" + (int)GameManager.instance.distanceEnd + "m";
    }
}
