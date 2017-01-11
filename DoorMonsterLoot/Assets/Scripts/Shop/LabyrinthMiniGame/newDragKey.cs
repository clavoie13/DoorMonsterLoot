using UnityEngine;
using System.Collections;

public class newDragKey : MonoBehaviour {

    float speed = 650;
    float maxSpeed = 650;
    Transform dragObj = null;
    RaycastHit2D hit;
    float length;
    int layermask;
    Vector3 screenPoint;
    Vector3 offset;
    bool OnKey = false;

    // Use this for initialization
    void Start () {
        layermask = 1 << 10;
    }
	
	// Update is called once per frame
	void Update () {

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layermask);
        Debug.Log(hit.collider);

        /*if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                screenPoint = Camera.main.WorldToScreenPoint(transform.position);

                offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


                OnKey = true;
            }
            

        }

        if(Input.GetMouseButtonUp(0))
        {
            OnKey = false;
        }*/


        if (hit.collider != null)
        {


            if (Input.GetMouseButton(0))
            {  // if left mouse button pressed...
               // cast a ray from the mouse pointer

                if(OnKey)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Debug.Log(ray.GetPoint(length) + offset);

                    if (!dragObj)
                    {  // if nothing picked yet...
                       // and the ray hit some rigidbody...
                        if (hit.collider != null)
                        {
                            Debug.Log("test");
                            dragObj = hit.transform;  // save picked object's transform
                            length = hit.distance;  // get "distance from the mouse pointer"
                        }
                    }
                    else
                    {  // if some object was picked...
                       // calc velocity necessary to follow the mouse pointer
                        var vel = ((ray.GetPoint(length) + offset) - dragObj.position) * speed;
                        // limit max velocity to avoid pass through objects
                        if (vel.magnitude > maxSpeed) vel *= maxSpeed / vel.magnitude;
                        // set object velocity
                        dragObj.GetComponent<Rigidbody2D>().velocity = vel;
                    }
                }
                else
                {  // no mouse button pressed
                    if (dragObj != null)
                    {
                        dragObj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        dragObj = null;  // dragObj free to drag another object
                    }
                }
            } 
        }
        else
        {
            if (dragObj != null)
            {
                dragObj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                dragObj = null;  // dragObj free to drag another object
            }
            OnKey = false;
        }
    }
}
