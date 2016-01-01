using UnityEngine;
using System.Collections;

public class AllySight : MonoBehaviour {
	public float lineOfSight = 160f;
	
	public GameObject[] targets { get; set;}
	
	private AllyMovement move;
	private AllyShooting shootScript;
	
	void Awake() {
		shootScript = GetComponent<AllyShooting>();
		move = GetComponent<AllyMovement>();
		targets = new GameObject[10];
	}
	
	void OnTriggerStay(Collider other) {
		if(other.CompareTag("Enemy") && !other.isTrigger) {
			
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			if(angle < lineOfSight * 0.5f) {
				Ray searchRay = new Ray();
				RaycastHit searchRayHit;
				
				searchRay.origin = transform.position;
				searchRay.direction = other.transform.position - transform.position;

				Debug.DrawRay(searchRay.origin, searchRay.direction, Color.blue);
				
				if(Physics.Raycast(searchRay, out searchRayHit, 50f) && searchRayHit.collider.tag == "Enemy") {
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
