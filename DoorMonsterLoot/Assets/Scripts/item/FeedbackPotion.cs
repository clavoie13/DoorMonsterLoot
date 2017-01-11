using UnityEngine;
using System.Collections;

public class FeedbackPotion : MonoBehaviour {

    public GameObject text;
    public GameObject image;
    TextMesh textMesh;
    SpriteRenderer imageSprite;
    float translation = 0.0f;

	// Use this for initialization
	void Start () {
        textMesh = text.GetComponent<TextMesh>();
        imageSprite = image.GetComponent<SpriteRenderer>();

        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * GameManager.instance.volumeGeneral;
        gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        
        translation = Time.deltaTime *2 ;
        transform.Translate(0, translation, 0);

        textMesh.color = new Vector4(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - 0.02f);
        imageSprite.color = new Vector4(imageSprite.color.r, imageSprite.color.g, imageSprite.color.b, imageSprite.color.a - 0.02f);

        if(imageSprite.color.a == 0)
        {
            Destroy(gameObject);
        }
    }

}
