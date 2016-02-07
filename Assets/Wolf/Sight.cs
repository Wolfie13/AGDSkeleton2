using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sight : MonoBehaviour {

    public float fov = 120f;
    public Vector3 lastPersonalSighting;
    public bool playerSighted;
    public bool packSighted;

    private SphereCollider col;
    private Animator anim;
    private LastPlayerSighting lastPackSighting;
    private GameObject player;
    private Vector3 lastFrame;

	// Use this for initialization
	void Start () 
    {
        col = gameObject.GetComponent<SphereCollider>();
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastPackSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
        lastPersonalSighting = new Vector3(0f, 0f, 0f);
        lastFrame = new Vector3(0f, 0f, 0f);

        lastFrame = lastPackSighting.dflt;
        lastPersonalSighting = lastPackSighting.dflt;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(packSighted)
        {
            if (lastPackSighting.lastWolfSighting != lastPersonalSighting)
            {
                lastPersonalSighting = lastPackSighting.lastWolfSighting;
            }
        }

        if (lastPackSighting.lastWolfSighting != lastPersonalSighting)
        {
            lastPersonalSighting = lastPackSighting.lastWolfSighting;    
        }

        lastFrame = lastPackSighting.lastWolfSighting;
	}

    void OnTriggerStay(Collider other)
    {

        if(other.gameObject == player)
        {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fov * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position +  transform.up / 2, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        Debug.Log("hit");
                        playerSighted = true;
                        lastPackSighting.lastWolfSighting = player.transform.position;
                    }
                    else
                    {
                        playerSighted = false;
                    }
                    
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player )
        {
            playerSighted = false;
        }
    }
    public void AlertPack(List<GameObject> pack)
    {
        foreach (GameObject wolf in pack)
        {
            lastPackSighting.Sighted(wolf);
        }
    }
    public void Reset()
    {
        lastFrame = lastPackSighting.dflt;
        lastPersonalSighting = lastPackSighting.dflt;
    }
}

