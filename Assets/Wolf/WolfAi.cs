using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolfAi : MonoBehaviour
{
    private NavMeshAgent nav;
    private Player player;
	public bool debugMode = false;

	public AudioClip screechSound = null;
	public AudioClip attackSound = null;
	public AudioClip deathSound = null;

	public float health;

	private float stunTime = 0;

	const float ATTACK_DELAY = 2;
	float attackCoolDown = -1;

	float lastDistance = 0;

    void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
		player = GameObject.FindObjectOfType<Player> ();
    }

	public void Stun(float seconds)
	{
		stunTime = seconds;
	}


    void Update()
    {
		if (health < 0) {
			return;
		}
		if (stunTime < 0) {
			nav.SetDestination (player.transform.position);
			float distanceToPlayer = Vector3.Distance (player.transform.position, this.transform.position);
			if (distanceToPlayer < 10) {
				if (lastDistance < 15) {
					if (lastDistance > 15) { //If we ended up within 10 metres on this frame.
						//Play spooky wolf bark.
						//AudioSource.PlayClipAtPoint(screechSound, this.transform.position);
					}
				}
				nav.speed = 4;
				if (distanceToPlayer < 2) {
					Attack ();
				}
			} else {
				nav.speed = 9;
			}
			
			if (attackCoolDown > 0) {
				attackCoolDown -= Time.deltaTime;
			}

			lastDistance = distanceToPlayer;
		} else {
			stunTime -= Time.deltaTime;
		}
    }

	void Attack() {
		if (attackCoolDown < 0) {
			Debug.Log ("munch!");
			player.health -= 35;
			attackCoolDown = ATTACK_DELAY;
		}
	}
}
