using UnityEngine;
using System.Collections;

public class DamageMe : MonoBehaviour {

	public int maxHealth;
	int health;
	public int damage;


	// Use this for initialization
	void Start () {
		health = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (health < 1) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.CompareTag ("BULLET")) {
			print ("collided");
			health -= 1;
		}
	}
}
