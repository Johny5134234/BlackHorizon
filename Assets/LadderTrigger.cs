using UnityEngine;
using System.Collections;

public class LadderTrigger : MonoBehaviour {

	public float ladderMoveSpeed = 0.15f;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
                Debug.Log("Collided with an object");
                if (Input.GetKey(KeyCode.W)) {
                        Debug.Log("Collided with object and W key pressed");
                        Rigidbody2D otherBody = other.attachedRigidbody;
	        	otherBody.velocity = new Vector2(otherBody.velocity.y, ladderMoveSpeed);
                }
	}

        void OnCollisionEnter2D(Collision2D thing) {
                Debug.Log("Something collided");
        }

	// Update is called once per frame
	void Update () {
	
	}
}
