using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float health { get; set; }

	void Awake() {
		health = 25;
	}

	void Update() {
		if(health <= 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.collider.CompareTag("Bullet")) {
			print ("BulletHitOnEnemy");
			health -= 5f;
		}
	}
}
