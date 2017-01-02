using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[SerializeField] private float moveSpeed, rotateSpeed, damage;
	private Pause pause;

	

	// Use this for initialization
	void Start () {
		pause = FindObjectOfType<Pause>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause.IsPaused){
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
			transform.GetChild(0).RotateAround(transform.position, new Vector3(0,0,-1), rotateSpeed *Time.deltaTime);
		} 
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Shredder"){
			Destroy (gameObject);
		} else if (other.tag == "Attacker"){
			Health enemyHealth = other.GetComponent<Health>();
			enemyHealth.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
