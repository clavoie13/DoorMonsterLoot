using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour
{

    public GameObject ScoreGlobal;
    TextMesh SGtext;

    private Vector2 previousPosition;
    private Vector2 distanceBetWeenDrag;

    bool JeVeuxDezoomer = false;

    float xPourDezoomer = 0;

    bool remmetreCamPasZoomer = false;

    // Use this for initialization
    void Start()
    {
        SGtext = ScoreGlobal.GetComponent<TextMesh>();

        if (PlayerPrefs.HasKey("ScoreGlobal"))
        {
            Debug.Log(PlayerPrefs.GetInt("ScoreGlobal"));
            SGtext.text = PlayerPrefs.GetInt("ScoreGlobal").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("ScoreGlobal", 0);
            SGtext.text = "0";
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Camera.main.orthographicSize > 4.99f && transform.position.x == xPourDezoomer && transform.position.y == -4 )
        {
            JeVeuxDezoomer = false;
        }

        if (JeVeuxDezoomer)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5.0f, 50 * Time.deltaTime);

            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -4, transform.position.z), 50 * Time.deltaTime);
            //Camera.main.orthographicSize = 5f;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPourDezoomer, -4, transform.position.z), 50 * Time.deltaTime);

            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(anciennePositionMap.x, anciennePositionMap.y, transform.position.z), 50 * Time.deltaTime);


            //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5.0f, 50 * Time.deltaTime);

            
            Debug.Log("Log");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            previousPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        distanceBetWeenDrag = objPosition - previousPosition;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x + distanceBetWeenDrag.x, -15, 4), transform.position.y);

        previousPosition = objPosition;

    }

    void OnMouseDown()
    {

        Debug.Log("Ici");

        if (Camera.main.orthographicSize == 2.5f)
        {
            JeVeuxDezoomer = true;
            /*Debug.Log("la postion en x : " +transform.position.x);
            Debug.Log("xPourDezoom avant calcul : " + xPourDezoomer);
            xPourDezoomer = transform.position.x + xPourDezoomer;
            Debug.Log("Xpourdezoom : " + xPourDezoomer);*/
        }
    }

    public void XAAller(float leVieuX)
    {
        xPourDezoomer = leVieuX;
    }
}
