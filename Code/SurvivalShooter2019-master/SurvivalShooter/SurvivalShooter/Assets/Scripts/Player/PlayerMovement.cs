﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Player Movement Speed
	public float speed = 6f;
	// Reference to the Vector3
	private Vector3 movement;
	// Reference to Animator Component
	private Animator anim;
	// Reference to the Rigidbody
	private Rigidbody playerRigidbody;
	// Reference for the mask
	private int floorMask;
	// Length from the camera into the world
	private float camRayLength = 100f;


	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move(h, v);
		Turning();
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("IsWalking", walking);
	}
}