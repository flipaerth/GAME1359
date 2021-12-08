using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTwoFollow : MonoBehaviour
{
	public float smoothing = 5f;

	private Vector3 offset;

	void Start()
	{
		GameObject target = GameObject.FindGameObjectWithTag("PlayerTwo");
		offset = transform.position - target.transform.position;
	}

	void FixedUpdate()
	{
		GameObject target = GameObject.FindGameObjectWithTag("PlayerTwo");
		Vector3 targetCamPos = target.transform.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
