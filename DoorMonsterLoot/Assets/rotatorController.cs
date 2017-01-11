using UnityEngine;
using System.Collections;

public class rotatorController : MonoBehaviour {

    public GameObject coffre;

    Vector2 GesturePoint;
    float OriginalRotAng;
    float OriginalTouchAng;
    float RotationAngle;
    float previousAngle;

    bool FiniLaBase = false;

    public float difficulty = 10;

    public int idDeLaRoue;

    // Use this for initialization
    void Start () {

        setDifficulty();

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;


    }

    // Update is called once per frame
    void Update () {
        if(FiniLaBase)
        {
            gameObject.transform.rotation = Quaternion.AngleAxis(RotationAngle, Vector3.forward);
        }
        
    }

    void OnMouseDrag()
    {
        if(FiniLaBase)
        {
            Debug.Log("Je drag");
            Vector2 SpinnerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            GesturePoint = Input.mousePosition;
            SpinnerScreenPoint = (GesturePoint - SpinnerScreenPoint);
            float newRot = Mathf.Atan2(SpinnerScreenPoint.y, SpinnerScreenPoint.x) * Mathf.Rad2Deg - 90;
            RotationAngle = OriginalRotAng + newRot - OriginalTouchAng;


            if(idDeLaRoue == 1)
            {
                if (previousAngle > transform.eulerAngles.z)
                {

                    if (!gameObject.GetComponent<AudioSource>().isPlaying)
                    {
                        gameObject.GetComponent<AudioSource>().Play();

                    }
                    coffre.transform.Translate(Vector2.up / difficulty);

                }
            }
            else
            {
                if (previousAngle < transform.eulerAngles.z)
                {

                    if (!gameObject.GetComponent<AudioSource>().isPlaying)
                    {
                        gameObject.GetComponent<AudioSource>().Play();

                    }

                    coffre.transform.Translate(Vector2.up / difficulty);

                }
            }

            previousAngle = transform.eulerAngles.z;
        }
    }

    void OnMouseDown()
    {

        Vector2 SpinnerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //OriginalRotAng = (Mathf.Atan2(SpinnerScreenPoint.y, SpinnerScreenPoint.x) * Mathf.Rad2Deg - 90);
        OriginalRotAng = transform.eulerAngles.z;
        previousAngle = transform.eulerAngles.z;

        Debug.Log(OriginalRotAng);

        GesturePoint = Input.mousePosition;
        SpinnerScreenPoint = (GesturePoint - SpinnerScreenPoint);

        OriginalTouchAng = (Mathf.Atan2(SpinnerScreenPoint.y, SpinnerScreenPoint.x) * Mathf.Rad2Deg - 90);

        FiniLaBase = true;   
    }

    void OnMouseUp()
    {
        FiniLaBase = false;
    }

    void setDifficulty()
    {
        difficulty = difficulty + GameManager.instance.floor * 0.5f;
    }

}
