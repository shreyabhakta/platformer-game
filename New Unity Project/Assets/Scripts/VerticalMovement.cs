using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour {
	public float speed = 2f;
	public bool movingUp = false;
	
    // Update is called once per frame
    void Update() {
		if(movingUp) {
			transform.Translate(0, 2 * Time.deltaTime * speed, 0);
			//transform.localScale = new Vector2 (0.375f,0.375f);
		}
		else {
			transform.Translate(0, -2 * Time.deltaTime * speed, 0);
			//transform.localScale = new Vector2 (-0.375f,0.375f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "turn") {
			if(movingUp == true) {
				movingUp = false;
			}
			else {
				movingUp = true;
			}
		}
	}
}
