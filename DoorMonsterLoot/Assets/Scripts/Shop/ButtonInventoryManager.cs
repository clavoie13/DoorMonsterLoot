using UnityEngine;
using System.Collections;

public class ButtonInventoryManager : MonoBehaviour {

    public int index;
    private bool Occupe = false;

	// Use this for initialization
	void Start () {
	    if (IventoryManager.instance.isOccupe(index) == true)
        {
            GameObject myItem = Instantiate (IventoryManager.instance.getItem(index), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            //TestItem testItem = myItem.GetComponent<TestItem>();

            //testItem.index = index;

            myItem.transform.parent = gameObject.transform;

            Occupe = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
        if(!Occupe)
        {
            if (IventoryManager.instance.isOccupe(index) == true)
            {
                GameObject myItem = Instantiate(IventoryManager.instance.getItem(index), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                //TestItem testItem = myItem.GetComponent<TestItem>();

                //testItem.index = index;

                myItem.transform.parent = gameObject.transform;

                Occupe = true;
            }
        }
        else
        {
            if (!IventoryManager.instance.isOccupe(index))
            {
                Occupe = false;
            }
        }
	}
}
