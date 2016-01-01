using UnityEngine;
using System.Collections;

public class AllyShooting : MonoBehaviour {

	public GameObject Target { get; set; }
	public GameObject bulletPrefab;
	public GameObject muzzle;

	
	private AllyMovement move;
	private NavMeshAgent nav;
	private float shotTimer;

	private Ray shootRay;
	private RaycastHit shootRayHit;

	private float bulletVariation = 0.02f;
	private int bulletSpeed = 40;
	
	void Awake() {
		nav = GetComponent<NavMeshAgent>();
		move = GetComponent<AllyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Target && inSight()) {
			transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
			
			shotTimer += Time.deltaTime;
			if(shotTimer >= Random.Range(1f, 4f)) {
				shotTimer = 0.0f;
				GameObject bullet = (GameObject) Instantiate(bulletPrefab, muzzle.transform.position, transform.rotation);
				bullet.GetComponent<Rigidbody>().velocity = bulletAim();
				//Target.GetComponent<Enemy>().kill();
			}
		} else {
			this.enabled = false;
			move.enabled = true;
		}
	}
	
	void OnEnable() {
		nav.SetDestination(transform.position);
		shotTimer = 0.0f;
	}
	
	void OnTriggerExit(Collider other) {
		if(other.CompareTag("Enemy")) {
			this.enabled = false;
			move.enabled = true;
		}
	}

	private bool inSight() {
		shootRay.origin = transform.position;
		shootRay.direction = Target.transform.position - transform.position;
		
		if(Physics.Raycast(shootRay, out shootRayHit, 100f) && shootRayHit.collider.CompareTag(Target.tag)) {
			return true;
		}
		return false;
	}

	private Vector3 bulletAim() {
		float vx = Random.Range(-bulletVariation, bulletVariation);
		float vy = Random.Range(-bulletVariation, bulletVariation);
		float vz = Random.Range(-bulletVariation, bulletVariation);
		
		Vector3 aim = new Vector3(transform.forward.x + vx, transform.forward.y + vy, transform.forward.z + vz);
		return aim * bulletSpeed;
	}
}
