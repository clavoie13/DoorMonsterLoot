using UnityEngine;
using System.Collections;

public class boutonDirection : MonoBehaviour {

    public int idBouton;
    public GameObject laCle;
    public GameObject leManagerLaby;

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;


    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Vector4(0.8f, 0.8f, 0.8f, 1);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);

        gameObject.GetComponent<AudioSource>().Play();

        switch (idBouton)
        {
            case 0:
                Debug.Log("Droite");
                laCle.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
                break;

            case 1:
                laCle.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;

                Debug.Log("Gauche");

                break;

            case 2:
                laCle.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;

                Debug.Log("Haut");

                break;

            case 3:
                laCle.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;

                Debug.Log("Bas");

                break;

            default:
                break;
        }
    }

    void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);

        leManagerLaby.GetComponent<LabyManager>().verifierSiOnChange();
    }
}
