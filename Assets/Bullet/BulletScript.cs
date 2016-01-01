using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer >= 5.0f) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(!other.isTrigger) {
			Destroy(gameObject);
		}
	}
}
