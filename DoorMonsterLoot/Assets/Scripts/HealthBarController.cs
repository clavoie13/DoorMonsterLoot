using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

    public GameObject healthBar;

    private float pourcentage;
    private int previousHealth;

	// Use this for initialization
	void Start () {
        pourcentage = (float)GameManager.instance.CurrentHealth / (float)GameManager.instance.MaxHealth;
        healthBar.transform.localScale = new Vector3(pourcentage * 10, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        previousHealth = GameManager.instance.CurrentHealth;

        GetComponent<TextMesh>().text = "" + GameManager.instance.CurrentHealth + "/" + GameManager.instance.MaxHealth;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.CurrentHealth != previousHealth)
        {
            pourcentage = (float)GameManager.instance.CurrentHealth / (float)GameManager.instance.MaxHealth;
            healthBar.transform.localScale = new Vector3(pourcentage * 10, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

            previousHealth = GameManager.instance.CurrentHealth;

            GetComponent<TextMesh>().text = "" + GameManager.instance.CurrentHealth + "/" + GameManager.instance.MaxHealth;
        }
	}
}
