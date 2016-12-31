using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	[SerializeField] private Projectile projectile;
	[SerializeField] private GameObject fireLocation;

	private Animator anim;
	private GameObject parent;
	
	// Use this for initialization
	void Start () {
		anim = GameObject.FindObjectOfType<Animator>();
		parent = GameObject.Find("Projectiles");
		if (!parent){
			parent = new GameObject("Projectiles");
		} 
	}
	
	// Update is called once per frame
	void Update () {
		Attack();
	}

	private void Attack(){
		string currentLane = transform.position.y.ToString();
		GameObject lane = GameObject.Find("Lane"+currentLane);
		if (lane.transform.childCount != 0){
			foreach(Transform attacker in lane.transform){
				if (attacker.transform.position.x >= transform.position.x){
					anim.SetBool("isAttacking", true);
				} else {
					anim.SetBool ("isAttacking", false);
				}
			}
		} else {
			anim.SetBool("isAttacking", false);
		}
	}


	private void Fire(){
		Projectile newProjectile = Instantiate(projectile, fireLocation.transform.position, Quaternion.identity) as Projectile;
		//newProjectile.transform.parent = gameObject.transform;
		newProjectile.transform.parent = parent.transform;
	}
}
