using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {
	public Button[] levelButtons;
	public Image[] gates;
    // Start is called before the first frame update
    void Start() {
		int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        
		for(int i = 0; i < levelButtons.Length; i++) {
			if( i + 1 > levelAt) {
				levelButtons[i].interactable = false;
				gates[i].enabled = true;
			}
			else {
				gates[i].enabled = false;
			}
		}
    }


}
