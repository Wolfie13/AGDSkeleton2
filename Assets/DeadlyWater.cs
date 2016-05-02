using UnityEngine;
using System.Collections;

public class DeadlyWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Player>() != null) {
			other.GetComponent<Player>().health = -100;
		}
	}
}
