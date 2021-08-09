using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector2 offset;
	public float distaceFromScreen;

	public bool lead;
	public float maxLead;
	public float leadModifier;

	[HideInInspector]
	public Vector3 currentPosition;

	Rigidbody2D targetRB;
	

    void FixedUpdate()
	{
		targetRB = target.GetComponent<Rigidbody2D>();
		if (target == null)
		{
			return;
		}

		/*
		 Big T's code in case i jack it all up:
		Vector2 desiredPosition = new Vector2(target.position.x, target.position.y) + offset;
		*/
		
		Vector2 forwardTravel = targetRB.velocity;
		
		// Ternary if statements that make no sense but ensure max lead is not exceeded by a positive or negative
		if(Math.Abs(forwardTravel.x) >= maxLead) {
			forwardTravel.x = forwardTravel.x > 0 ? maxLead : maxLead * -1;
        }

		if (Math.Abs(forwardTravel.y) >= maxLead) {
			forwardTravel.y = forwardTravel.y > 0 ? maxLead : maxLead * -1;
		}


		// Toggles lead
		if (!lead) {
			forwardTravel = new Vector2(0, 0);
        }

		Vector2 desiredPosition = new Vector2(target.position.x + forwardTravel.x, target.position.y + forwardTravel.y) + offset;
		Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, distaceFromScreen);
		currentPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, distaceFromScreen);


		//transform.LookAt(target);
	}

}

