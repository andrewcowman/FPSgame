using UnityEngine;
using System.Collections;

public class AllyMovement : MonoBehaviour {

	public bool needNewSearchPosition { get; set; }
	public GameObject[] searchPositions;
	
	private NavMeshAgent nav;
	private int prevSearch = -1;
	private int currSearch = -1;
	
	void Awake() {
		nav = GetComponent<NavMeshAgent>();
		searchPositions = GameObject.FindGameObjectsWithTag("SearchPosition");
	}
	
	// Update is called once per frame
	void Update () {
		if(needNewSearchPosition) {
			generateNewSearchPosition();
		}
	}
	
	void OnEnable() {
		if(currSearch != -1) {
			nav.SetDestination(searchPositions[currSearch].transform.position);
		} else {
			generateNewSearchPosition();
		}
	}
	
	private void generateNewSearchPosition() {
		prevSearch = currSearch;
		//nav.SetDestination(new Vector3(Random.Range(-30, 30), 4.4f, Random.Range(-30, 30)));
		int random = Random.Range(0, searchPositions.Length);
		if(random == prevSearch) {
			if(random == 0) {
				random++;
			} else {
				random--;
			}
		}
		currSearch = random;
		nav.SetDestination(searchPositions[random].transform.position);
		needNewSearchPosition = false;
	}
}
