using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health = 100;
	public bool debugMode = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!debugMode) {
			if (!debugMode) { 
				Application.LoadLevel ("DeathScreen");
			}
		}
	}

	void OnGUI() {
		if (debugMode) {
			GUI.Label(new Rect(10, 50, 200, 40), "Health: " + health);
		}

	}
}
