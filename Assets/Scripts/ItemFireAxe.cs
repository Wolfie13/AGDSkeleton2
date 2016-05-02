using UnityEngine;
using System.Collections;

public class ItemFireAxe : Item {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("swing", swinging);
	}

	bool swinging = false;

	public Animator anim;

	public override void Fire (ItemInventory caller) {
		//Take a swing, brah.
		//TODO: Deal damage to the struck enemy/object.
		swinging = true;
	}

	void OnTriggerEnter(Collider other) {
		if (swinging) {
			Debug.Log("Swing!");
			if (other.GetComponent<WolfAi> () != null) {
				WolfAi wolf = other.GetComponent<WolfAi> ();
				wolf.health -= 52;
				AudioSource.PlayClipAtPoint(wolf.deathSound, wolf.transform.position);
				swinging = false;
			}
		}
	}

	void EndSwing()
	{
		swinging = false;
	}
	
}
