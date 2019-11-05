using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter {
	protected BoxCollider2D boxCollider;
	private Vector3 moveDelta;
	private RaycastHit2D hit;
	public Rigidbody2D rb;
	protected float ySpeed = 0.75f;
	protected float xSpeed = 1.0f;

	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
	}
	
	protected virtual void UpdateMotor(Vector3 input) {
		// Reset MoveDelta
		moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

		// Swap Sprite Right or Left
		if (moveDelta.x > 0)
			transform.localScale = Vector3.one;
		else if(moveDelta.x < 0)
			transform.localScale = new Vector3(-1,1,1);

		// Make sure we can move by casting a box there first, if the box returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
								new Vector2(0,moveDelta.y),
								Mathf.Abs(moveDelta.y * Time.deltaTime),
								LayerMask.GetMask("Actor", "Blocking"));

		if (hit.collider == null) {
			transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
		}
		// Make sure we can move by casting a box there first, if the box returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
								new Vector2(0,moveDelta.x), 
								Mathf.Abs(moveDelta.x * Time.deltaTime), 
								LayerMask.GetMask("Actor", "Blocking"));
								
		if (hit.collider == null) {
			transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
		}
	}
}
