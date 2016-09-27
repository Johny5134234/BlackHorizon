using UnityEngine;
using System.Collections;
public class BasicCharacter : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;

	bool isGrounded;

	// Use this for initialization
	void Start () {
	}

	void fixedUpdate() {

	}

	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		Rigidbody2D characterRigidBody = GetComponent<Rigidbody2D>();
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			characterRigidBody.velocity = new Vector2 (characterRigidBody.velocity.x, jumpHeight);
		}
		if (Input.GetKey (KeyCode.D)) {
			characterRigidBody.velocity = new Vector2 (moveSpeed, characterRigidBody.velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			characterRigidBody.velocity = new Vector2 (-moveSpeed, characterRigidBody.velocity.y);
		}
	}
}
