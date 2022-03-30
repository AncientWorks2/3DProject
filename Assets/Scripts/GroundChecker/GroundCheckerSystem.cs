using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerSystem : MonoBehaviour
{
	[SerializeField]
	private LayerMask groundLayer;
	[SerializeField]
	private float distance;
	[SerializeField]
	private RaycastHit hit;

	private void FixedUpdate()
    {
		GroundCheckerManager.isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, distance, groundLayer);

		// Does the ray intersect any objects excluding the player layer
		if (GroundCheckerManager.isGrounded)
		{
			Debug.DrawRay(transform.position, Vector3.down * distance, Color.yellow);
		}
		else
		{
			Debug.DrawRay(transform.position, Vector3.down * distance, Color.white);
		}
	}
}
