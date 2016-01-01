using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float lineOfSight = 160f;

	public GameObject[] targets { get; set;}

	private TMovement move;
	private EnemyShooting shootScript;

	void Awake() {
		shootScript = GetComponent<EnemyShooting>();
		move = GetComponent<TMovement>();
		targets = new GameObject[10];
	}

	void OnTriggerStay(Collider other) {
		if((other.CompareTag("Player") || other.CompareTag("Ally")) && !other.isTrigger) {

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < lineOfSight * 0.5f) {
				Ray searchRay = new Ray();
				RaycastHit searchRayHit;
				
				searchRay.origin = transform.position;
				searchRay.direction = other.transform.position - transform.position;
				
				if(Physics.Raycast(searchRay, out searchRayHit, 50f) && (searchRayHit.collider.CompareTag("Player") || searchRayHit.collider.CompareTag("Ally"))) {
					//int index = searchRayHit.collider.gameObject.GetComponent<PlayerScript>().playerNumber;
					//targets[index] = searchRayHit.collider.gameObject;

					shootScript.enabled = true;
					move.enabled = false;
					shootScript.Target = other.gameObject;
				}
			}
		}
	}	
}