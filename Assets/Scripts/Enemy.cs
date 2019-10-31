using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover {

    // Experience
    public int xpValue = 1;

    // Logic
    public float triggerLength=1;
    public float chaseLenght=5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    // Hitbox
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start() {
        base.Start();
        playerTransform =  GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        UpdateMotor(Vector3.zero); 
    }
}
