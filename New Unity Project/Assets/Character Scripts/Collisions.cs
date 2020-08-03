using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
	public Transform spawnpoint;
	private float coins = 0;
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Coins") {
			Destroy(other.gameObject);
		}
		if(other.transform.tag == "Water") {
			Respawn();
		}
	}
	
	
	void Respawn() {
		this.transform.position = spawnpoint.position;
	}

}
