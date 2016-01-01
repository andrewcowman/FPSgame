using UnityEngine;
using System.Collections;

public class SearchScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Enemy") && !other.isTrigger) {
			other.gameObject.GetComponent<TMovement>().needNewSearchPosition = true;
		} else if(other.CompareTag("Ally") && !other.isTrigger) {
			other.gameObject.GetComponent<AllyMovement>().needNewSearchPosition = true;
		}
	}
}
