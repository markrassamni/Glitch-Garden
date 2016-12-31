using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	[SerializeField] private Attacker[] attackers;

	void Start () {

	}
	
	void Update () {
		foreach(Attacker attacker in attackers){
			Spawn(attacker);
		}
	}

	private void Spawn(Attacker attacker){
		if (attacker.SpawnTime < Time.deltaTime ){
			Debug.LogWarning("Spawn rate capped by frame rate");
		} 
		if (Random.value < (Time.deltaTime/attacker.SpawnTime)/5){ // (time /spawnTime)/5lanes
			Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
			newAttacker.transform.parent = transform;
		}
		
	}

}
