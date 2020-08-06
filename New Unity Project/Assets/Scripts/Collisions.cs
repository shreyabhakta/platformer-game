using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collisions : MonoBehaviour {
	public int health = 3;
	public int numOfHearts = 3;
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	
	public Transform spawnpoint;
	private float coins = 0;
	public TextMeshProUGUI coinText;
	
    // Update is called once per frame
    void Update() {
		if(health > numOfHearts) {
			health = numOfHearts;
		}
        for(int i = 0; i < hearts.Length; i++) {
        	if(i < health) {
        		hearts[i].sprite = fullHeart;
        	}
			else {
				hearts[i].sprite = emptyHeart;
			}
			
			if(i < numOfHearts) {
				hearts[i].enabled = true;
			}
			else {
				hearts[i].enabled = false;
			}
        }
    }
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Coins") {
			coins++;
			coinText.text = coins.ToString();
			Destroy(other.gameObject);
		}
		if(other.transform.tag == "Water" || other.transform.tag == "Enemy") {
			--health;
			Respawn();
		}
	}
	
	
	void Respawn() {
		this.transform.position = spawnpoint.position;
	}

}
