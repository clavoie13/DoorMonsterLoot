using UnityEngine;
using System.Collections;

public class ScoreBoardController : MonoBehaviour {

    public GameObject Scoretext;
    public GameObject Floortext;
    public GameObject Doortext;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Camera.main.orthographicSize > 4.95)
        {
            Destroy(gameObject);
        }
	}

    public void setText(int score, int floor, int door)
    {
        Scoretext.GetComponent<TextMesh>().text = score.ToString();
        Floortext.GetComponent<TextMesh>().text = floor.ToString();
        Doortext.GetComponent<TextMesh>().text = door.ToString();
    }
}
