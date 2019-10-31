using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	public int hitPoint = 10;
	public int maxHitPoint= 10;
	public float  pushRecoverySpeed = 0.2f;
	protected float immuneTime = 1.0f;
	protected float lastImmune;

	protected Vector3 pushDirection;

	// All fighters can Receive Damage / Die
	protected virtual void ReceiveDamage(Damage dmg) {
		if (Time.time - lastImmune > immuneTime) {
			lastImmune = Time.time;
			hitPoint -= dmg.damageAmount;
			pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

			// Damage indication sprites
			GameManager.instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);
			if (hitPoint <= 0) {
				hitPoint = 0;
				Death();
			}
		}
	}
	protected virtual void Death() {

	}
}
