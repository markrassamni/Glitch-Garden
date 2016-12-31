using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] private float _health = 100f;

	public float health {
		get {
			return _health;
		}
	}

	public void DealDamage(float damage){
		_health -= damage;
		if (health < 0){
			Die();
		}
	}

	public void Die(){
		//animation?
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
