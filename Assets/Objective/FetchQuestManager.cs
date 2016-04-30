using UnityEngine;
using System.Collections;

public class FetchQuestManager : MonoBehaviour {
	private int itemsCollected = 0;
	bool display = false;
	float displayTime = 0f;

	// Use this for initialization
	void Start () {
	
	}

	public void Collect() {
		itemsCollected++;
		display = true;
		displayTime = 2f;
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

		if (itemsCollected >= 3) {
			//Time to escape.
		}
	}

	void OnGUI() {
		if (display) {
			GUI.Label(new Rect(10, 10, 200, 40), "Collected: " + itemsCollected);
		}
	}
}
