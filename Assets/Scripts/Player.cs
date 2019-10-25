using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private Vector3 moveDelta;
	private RaycastHit2D hit;
	public Rigidbody2D rb;
	// private void Awake()
	// Use this for initialization
	private void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		// Reset MoveDelta
		moveDelta = new Vector3(x,y,0);

		// Swap Sprite Right or Left
		if (moveDelta.x > 0)
			transform.localScale = Vector3.one;
		else if(moveDelta.x < 0)
			transform.localScale = new Vector3(-1,1,1);

		// Make sure we can move by casting a box there first, if the box returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,
								new Vector2(0,moveDelta.y),
								Mathf.Abs(moveDelta.y * Time.deltaTime),
								LayerMask.GetMask("Actor", "Blocking"));

		if (hit.collider == null)
		{
			transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
		}
		// Make sure we can move by casting a box there first, if the box returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
								new Vector2(0,moveDelta.x), 
								Mathf.Abs(moveDelta.x * Time.deltaTime), 
								LayerMask.GetMask("Actor", "Blocking"));
								
		if (hit.collider == null)
		{
			transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
		}
	}
}
