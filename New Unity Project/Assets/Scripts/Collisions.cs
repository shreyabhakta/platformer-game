using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour {
	public int health = 3;
	public int numOfHearts = 3;
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	public Transform spawnpoint;
	public TextMeshProUGUI coinText;
	public int nextSceneLoad;
	private float coins = 0;
	
	// Start is called before the first frame update
	void Start() {
		nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}
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
		if(other.transform.tag == "Finish") {
			if(SceneManager.GetActiveScene().buildIndex == 12) {
				Debug.Log("YOU HAVE COMPLETED THE GAME");
				//Win Screen/Options
			}
			else {
				//Move to the next level
				SceneManager.LoadScene(nextSceneLoad);
				//Set int for Index
				if(nextSceneLoad > PlayerPrefs.GetInt("levelAt")) {
					PlayerPrefs.SetInt("levelAt", nextSceneLoad);
				}
			}
		}
	}
	
	
	void Respawn() {
		this.transform.position = spawnpoint.position;
	}

}
