﻿using UnityEngine;
using System.Collections;

public class LadderTrigger : MonoBehaviour {

	public float ladderMoveSpeed = 0.15f;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
                Rigidbody2D otherBody = other.attachedRigidbody;
		otherBody.AddForce(new Vector2(otherBody.velocity.y, ladderMoveSpeed));
	}

	// Update is called once per frame
	void Update () {
	
	}
}
