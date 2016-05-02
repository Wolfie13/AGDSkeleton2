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

	public Animator anim;

	public float health = 100;

	private float stunTime = 0;

	const float ATTACK_DELAY = 2;
	float attackCoolDown = -1;

	float lastDistance = 0;

	Vector3 spawnPoint = Vector3.zero;

    void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
		player = GameObject.FindObjectOfType<Player> ();
		spawnPoint = this.transform.position;
		anim.SetBool ("active", true);
    }

	public void Stun(float seconds)
	{
		stunTime = seconds;
	}


    void Update()
    {
		if (health < 0) {
			anim.SetBool("dead", true);
			return;
		}

		float distanceToPlayer = Vector3.Distance (player.transform.position, this.transform.position);

		if (stunTime < 0) {

			if (nav.remainingDistance > 100 && Vector3.Distance(this.transform.position, spawnPoint) > 200)	{
				nav.SetDestination(spawnPoint);
			} else {
				nav.SetDestination (player.transform.position);
			}

			if (distanceToPlayer < 15) {
				if (lastDistance > 15) { //If we ended up within 10 metres on this frame.
					//Play spooky wolf bark.
					AudioSource.PlayClipAtPoint(screechSound, this.transform.position);
				}
			}
			if (distanceToPlayer < 10) {
				nav.speed = 4;
				if (distanceToPlayer < 1) {
					Attack ();
				}
			} else {
				nav.speed = 9;
			}
			
			if (attackCoolDown > 0) {
				attackCoolDown -= Time.deltaTime;
			}

		} else {
			stunTime -= Time.deltaTime;
		}

		lastDistance = distanceToPlayer;
    }

	void Attack() {
		if (attackCoolDown < 0) {
			Debug.Log ("munch!");
			player.health -= 35;
			anim.SetTrigger("attack");
			AudioSource.PlayClipAtPoint (attackSound, this.transform.position);
			attackCoolDown = ATTACK_DELAY;
		}
	}
}
