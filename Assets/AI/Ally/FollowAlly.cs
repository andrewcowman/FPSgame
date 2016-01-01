using UnityEngine;
using System.Collections;

public class FollowAlly : MonoBehaviour {

	private NavMeshAgent nav;
	private float distance;
	private GameObject human;

	private bool shouldMove = true;
	
	// Use this for initialization
	void Awake () {
		nav = GetComponent<NavMeshAgent>();
		human = GameObject.Find("Human");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(transform.position, human.transform.position);

		if(distance < 5.0f) {
			shouldMove = false;
		}

		if(human != null && shouldMove) {
			nav.SetDestination(GameObject.Find("Human").transform.position);
		} else {
			nav.SetDestination(transform.position);
		}

		 
	}
}
