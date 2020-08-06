using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour {
	public float speed = 2f;
	public bool movingRight = false;
	
    // Start is called before the first frame update
    void Start() {
        
    }
	
    // Update is called once per frame
    void Update() {
		if(movingRight) {
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			//transform.localScale = new Vector2 (0.375f,0.375f);
		}
		else {
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			//transform.localScale = new Vector2 (-0.375f,0.375f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "turn") {
			if(movingRight == true) {
				movingRight = false;
			}
			else {
				movingRight = true;
			}
		}
	}
}
