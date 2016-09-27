using UnityEngine;
using System.Collections;
public class BasicCharacter : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	bool Grounded;

	private float distToGround;
	private Rigidbody2D characterRigidBody;

	// Use this for initialization
	void Start () {
	}

	bool Grounded;

	void OnCollisionStay2D(Collision2D collider)
	{
		    CheckIfGrounded ();
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		    Grounded = false;
	}

	private void CheckIfGrounded()
	{
		    RaycastHit2D[] hits;
		    Vector2 positionToCheck = transform.position;
		    hits = Physics2D.RaycastAll (positionToCheck, new Vector2 (0, -1), 0.01f);
		    if (hits.Length > 0) {
			    Grounded = true;
		    }
	}

			
	bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	void fixedUpdate() {
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D characterRigidBody = GetComponent<Rigidbody2D>();
		if (Input.GetKeyDown (KeyCode.Space) && Grounded) {
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
