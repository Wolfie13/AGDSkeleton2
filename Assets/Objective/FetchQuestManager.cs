using UnityEngine;
using System.Collections.Generic;

public class FetchQuestManager : MonoBehaviour {
	private int itemsCollected = 0;
	bool display = false;
	float displayTime = 0f;
	public GameObject escapeZone = null;
	private GhostAI ghost = null;

	public List<AudioClip> spookNoises = new List<AudioClip>();
	// Use this for initialization
	void Start () {
		escapeZone.SetActive (false);
		ghost = GameObject.FindObjectOfType<GhostAI> ();
	}

	public void Collect() {
		itemsCollected++;
		display = true;
		displayTime = 2f;

		switch (itemsCollected) {
		case 1:
			//Enable Ghost
			ghost.SetSpeed(4);
			//Play Spooky Noise 1
			AudioSource.PlayClipAtPoint(spookNoises[0], ghost.transform.position);
			break;
		case 2:
			//Play Spooky Noise 2
			AudioSource.PlayClipAtPoint(spookNoises[1], ghost.transform.position);
			//Increase ghost speed
			ghost.SetSpeed(5);
			break;
		case 3:
			//Play spooky noise 3
			AudioSource.PlayClipAtPoint(spookNoises[2], ghost.transform.position);
			//Enable Escape
			ghost.SetSpeed(6);
			escapeZone.SetActive (true);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (display) {
			if (displayTime > 0f) {
				displayTime -= Time.deltaTime;
			} else {
				display = false;
			}
		}
	}

	void OnGUI() {
		if (display) {
			GUI.Label(new Rect(10, 10, 200, 40), "Collected: " + itemsCollected);
		}
	}
}
