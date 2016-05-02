using UnityEngine;
using System.Collections;

public class EscapeZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (this.isActiveAndEnabled) {
			if (other.GetComponent<Player>() != null) {
				Application.LoadLevel ("WinScreen");
			}
		}
	}
}
