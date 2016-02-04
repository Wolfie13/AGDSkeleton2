using UnityEngine;
using System.Collections;

public class ItemFireAxe : Item {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Fire (ItemInventory caller) {
		//Take a swing, brah.
		//TODO: Implement a hit-trace with limited range.
		//TODO: Deal damage to the struck enemy/object.
	}
}
