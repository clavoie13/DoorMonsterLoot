using UnityEngine;
using System.Collections;

public class DragKey : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody2D myRigidBody;
    private bool OverObject = false;

    private float minSwipeDistY = 50;
    private float minSwipeDistX = 50;
    private Vector2 startPos;

    int layermask;
    RaycastHit2D hit;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        layermask = 1 << 10;
    }
	
	// Update is called once per frame
	void Update () {


        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layermask);

        if (hit.collider != null)
        {
            OnMouseDrag();
            Debug.Log("OK");
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

            OverObject = true;
        }
        else
        {
            OverObject = false;
            myRigidBody.velocity = Vector3.zero;
        }

        /*
        if(Input.GetKey(KeyCode.D))
        {
            myRigidBody.AddForce(Vector2.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.AddForce(Vector2.left);
        }
        if (Input.GetKey(KeyCode.W))
        {
            myRigidBody.AddForce(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRigidBody.AddForce(Vector2.down);
        }

        if (OverObject)
        {
            if (Input.touchCount > 0)

            {

                Touch touch = Input.touches[0];



                switch (touch.phase)

                {

                    case TouchPhase.Began:

                        startPos = touch.position;

                        break;



                    case TouchPhase.Ended:

                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                        if (swipeDistVertical > minSwipeDistY)

                        {

                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                            if (swipeValue > 0)//up swipe
                            {
                                myRigidBody.AddForce(Vector2.up * 0.5f);
                            }
                            

                            else if (swipeValue < 0)//down swipe
                            {
                                myRigidBody.AddForce(Vector2.down * 0.5f);
                            }

                        }

                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                        if (swipeDistHorizontal > minSwipeDistX)

                        {

                            float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                            if (swipeValue > 0)//right swipe
                            {
                                myRigidBody.AddForce(Vector2.right * 0.5f);
                            }
                            //MoveRight ();

                            else if (swipeValue < 0)//left swipe
                            {
                                myRigidBody.AddForce(Vector2.left * 0.5f);
                            }
                            //MoveLeft ();

                        }
                        break;
                }
            }
        }
        */
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        OverObject = true;
    }

    void OnMouseDrag()
    {
        Debug.Log("Je drag");
        /*Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);


        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = Vector3.MoveTowards(transform.position, curPosition, 1);*/

        if (OverObject)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            myRigidBody.velocity = ((mousePosition - gameObject.transform.position) + offset).normalized * 650;
        }

        //transform.position = Vector2.Lerp(transform.position, mousePosition, 1f);

    }

    void OnMouseExit()
    {

        OverObject = false;
        myRigidBody.velocity = Vector3.zero;
    }

    void OnMouseUp()
    {
        OverObject = false;
        myRigidBody.velocity = Vector3.zero;
    }
}
