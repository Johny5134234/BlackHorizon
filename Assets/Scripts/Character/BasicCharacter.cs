using UnityEngine;
using System.Collections;
public class BasicCharacter : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public float distToGround;
	Rigidbody2D characterRigidBody;

	// Use this for initialisation
	void Start () {
		characterRigidBody = GetComponent<Rigidbody2D>();
		distToGround = collider.bounds.extents.y;
	}
	void fixedUpdate() {

	}

	void isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void test() {

	}
}
