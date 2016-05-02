using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {
	public Animator anim;
	private NavMeshAgent nav;
	private Player player;

	private float speed = 0;

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

	// Use this for initialization
	void Awake () {
		nav = gameObject.GetComponent<NavMeshAgent>();
		player = GameObject.FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {		
		float distanceToPlayer = Vector3.Distance (player.transform.position, this.transform.position);
			
		nav.SetDestination (player.transform.position);

		if (distanceToPlayer < 10) {
			nav.speed = 4;
			if (distanceToPlayer < 1) {
				Attack ();
			}
		} else {
			nav.speed = 9;
		}
	}

	void Attack() {
		Debug.Log ("rarrrr!");
		player.health -= 115;
	}
}
