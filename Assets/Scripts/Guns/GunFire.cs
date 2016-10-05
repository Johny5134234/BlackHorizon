using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour {

	public int maxHealth;
	int health;
	public int damage;


	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.CompareTag ("GROUND")) {
			health -= 0;
		}
	}
}
