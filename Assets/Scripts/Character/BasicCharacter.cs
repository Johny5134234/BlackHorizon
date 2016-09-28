using UnityEngine;
using System.Collections;
public class BasicCharacter : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public float bulletSpeed;

    int ammo = maxAmmo;
    public int maxAmmo = 50;

	float jumpCount = 0;
	public float maxJumps = 2;
        bool onLadder = false;

        public GameObject gunPrefab;
        public GameObject bulletPrefab;
        public Transform bulletSpawnLoc;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate() {
                handleMovement();
                handleShooting();
				handleGunPosition();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.collider.CompareTag("GROUND")) {
			jumpCount = 0;
		}
	}

        void OnTriggerEnter2D(Collider2D other) {
                if(other.CompareTag("LADDER")) {
                        onLadder = true;
                }
        }

        void OnTriggerExit2D(Collider2D other) {
                if(other.CompareTag("LADDER")) {
                        onLadder = false;
                }
        }

        // Update is called once per frame
	    void Update () {
    	}

        void handleShooting() {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position); 
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                

                if(Input.GetMouseButtonDown(0) && ammo > 0) {
                        GameObject bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawnLoc.position, bulletSpawnLoc.rotation);
						bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed; //Tweak this line
                        ammo--;
                }
        }

        void handleGunPosition() {
                gunPrefab.transform.position = gameObject.transform.position;
        }

        void handleMovement() {
			Rigidbody2D characterRigidBody = GetComponent<Rigidbody2D>();
			if (Input.GetKeyDown (KeyCode.Space) && jumpCount <= maxJumps) {
				characterRigidBody.velocity = new Vector2 (characterRigidBody.velocity.x, jumpHeight);
				jumpCount += 1;
			}
			if (Input.GetKey (KeyCode.D)) {
				characterRigidBody.velocity = new Vector2 (moveSpeed, characterRigidBody.velocity.y);
			}
			if (Input.GetKey (KeyCode.A)) {
				characterRigidBody.velocity = new Vector2 (-moveSpeed, characterRigidBody.velocity.y);
			}
            if (Input.GetKey (KeyCode.W) && onLadder) {
                characterRigidBody.velocity = new Vector2(characterRigidBody.velocity.x, moveSpeed);
            }
        }
}
