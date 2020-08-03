using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collisions : MonoBehaviour {
	public Transform spawnpoint;
	private float coins = 0;
	public TextMeshProUGUI coinText;
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Coins") {
			coins++;
			coinText.text = coins.ToString();
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
