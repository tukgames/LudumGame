using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector2 offset;
	public float distaceFromScreen;

	[HideInInspector]
	public Vector3 currentPosition;


	void FixedUpdate()
	{
		if (target == null)
		{
			return;
		}
		Vector2 desiredPosition = new Vector2(target.position.x, target.position.y) + offset;
		Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, distaceFromScreen);
		currentPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, distaceFromScreen);


		//transform.LookAt(target);
	}

}

