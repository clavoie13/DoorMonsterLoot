using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject skull;
    public GameObject posSkull;

    public float moveSpeed = 0;
    public float smoothSpeed = 10;

    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private bool zoomer = false;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();

        myRigidbody = gameObject.transform.parent.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);

        if(zoomer)
        {
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, 3.5f, smoothSpeed * Time.deltaTime);
            Camera.main.transform.localScale = new Vector3(Camera.main.orthographicSize / 5, Camera.main.orthographicSize / 5, Camera.main.transform.localScale.z);
            //Camera.main.transform.localPosition = Vector3.MoveTowards(Camera.main.transform.localPosition, new Vector3(3.5f, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z), smoothSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, 5f, smoothSpeed * Time.deltaTime);
            Camera.main.transform.localScale = new Vector3(Camera.main.orthographicSize / 5, Camera.main.orthographicSize / 5, Camera.main.transform.localScale.z);
            //Camera.main.transform.localPosition = Vector3.MoveTowards(Camera.main.transform.localPosition, new Vector3(5.5f, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z), smoothSpeed * Time.deltaTime);
        }
    }

    public void StartRunning()
    {
        GameManager.instance.StopTime = false;

        BarDeTempsController.StartLooseTime();

        zoomer = true;
        moveSpeed = 30;

        GameObject monSkull = Instantiate(skull, posSkull.transform.position, Quaternion.identity) as GameObject;
        monSkull.transform.SetParent(transform);

        BarDeTempsController.StartAddTime();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stop")
        {
            moveSpeed = 0;

            Destroy(other.gameObject);

            BarDeTempsController.StartLooseTime();
            zoomer = false;
        }
    }
}
