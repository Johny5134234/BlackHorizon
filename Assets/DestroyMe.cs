using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
	     //TODO Damage enemy possibly
	     Destroy(gameObject, 0.2f);
    }
}
