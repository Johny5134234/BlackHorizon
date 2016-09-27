using UnityEngine;
using System.Collections;
public class BasicCharacter : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private float distToGround;

	// Use this for initialization
	void Start () {
		distToGround = collider.bounds.extents.y;
	}

	bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
	}

	void fixedUpdate() {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded()) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void test() {

	}
}
