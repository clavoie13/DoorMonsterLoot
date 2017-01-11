using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public float plus = 0.04f;
    public float minus = 0.001f;
    int difficulter = 0;

	// Use this for initialization
	void Start () {
        difficulter = GameManager.instance.floor;

        switch (difficulter)
        {
            case 1:
                plus = 0.04f;
                minus = 0.001f;
                break;
            case 2:
                plus = 0.03f;
                minus = 0.001f;
                break;
            case 3:
                plus = 0.02f;
                minus = 0.001f;
                break;
            case 4:
                plus = 0.04f;
                minus = 0.0015f;
                break;
            case 5:
                plus = 0.03f;
                minus = 0.0015f;
                break;
            default:
                plus = 0.02f;
                minus = 0.0015f;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddTime()
    {
        gameObject.GetComponent<Image>().fillAmount += plus;
    }

    public void SubstractTime()
    {
        gameObject.GetComponent<Image>().fillAmount -= minus;
    }

    public float getFillAmount()
    {
        return gameObject.GetComponent<Image>().fillAmount;
    }

}
