using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	[SerializeField] private Projectile projectile;
	[SerializeField] private GameObject fireLocation;

	private GameObject parent;
	
	// Use this for initialization
	void Start () {
		parent = GameObject.Find("Projectiles");
		if (!parent){
			parent = new GameObject("Projectiles");
		} 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void Fire(){
		Projectile newProjectile = Instantiate(projectile, fireLocation.transform.position, Quaternion.identity) as Projectile;
		//newProjectile.transform.parent = gameObject.transform;
		newProjectile.transform.parent = parent.transform;
	}
}
