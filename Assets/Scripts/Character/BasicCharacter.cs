using UnityEngine;
using System.Collections;
public class BasicCharacter : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;

	float jumpCount = 0;
	public float maxJumps = 2;
	bool onLadder = false;

	// Use this for initialization
	void Start () {
	}

	void fixedUpdate() {

	}

	void OnCollisionEnter2D(Collision2D collision) {
		onLadder = false;
		if(collision.CompareTag("GROUND")) {
			jumpCount = 0;
		} else if(collision.CompareTag("LADDER")) {
			jumpCount = maxJumps;
			onLadder = true;
		}	
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D characterRigidBody = GetComponent<Rigidbody2D>();
		if (Input.GetKeyDown (KeyCode.Space) && jumpCount <= maxJumps) {
			characterRigidBody.AddForce(new Vector2(characterRigidBody.velocity.x, jumpHeight));
			jumpCount += 1;
		}
		if (Input.GetKey (KeyCode.D)) {
			characterRigidBody.AddForce(new Vector2(moveSpeed, characterRigidBody.velocity.y));
		}
		if (Input.GetKey (KeyCode.A)) {
			characterRigidBody.AddForce(new Vector2(-moveSpeed, characterRigidBody.velocity.y));
		}
		if (Input.GetKey(KeyCode.W) && onLadder) {
			characterRigidBody.AddForce(new Vector2(characterRigidBody.velocity.x, moveSpeed));
		}
	}
}
