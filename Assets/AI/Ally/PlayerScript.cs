using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public int playerNumber;

	public float health;

	public AudioClip gunshotsound;

	void Awake() {
		health = 25;
	}

	void Start () {
		print ("start");
	}

	void Update() {
		if(health <= 0) {
			if(this.CompareTag("Player")) {
				Application.LoadLevel("Lose");
			} else {
				Destroy(gameObject);
			}

		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.collider.CompareTag("Bullet")) {
			print ("BulletHitOnAlly");
			health -= 5f;
		}
	}

	void OnMouseDown(){
		audio.PlayOneShot (gunshotsound,1.0f);
		print ("click");
	}



}
