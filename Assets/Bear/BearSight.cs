using UnityEngine;
using System.Collections;

public class BearSight : MonoBehaviour {

    public float fov = 120f;
    public Vector3 lastPersonalSighting;
    public bool playerSighted;

    private SphereCollider col;
    private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    private GameObject player;
    private Vector3 lastFrame;

    // Use this for initialization
    void Start()
    {
        col = gameObject.GetComponent<SphereCollider>();
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
        lastPersonalSighting = new Vector3(0f, 0f, 0f);
        lastFrame = new Vector3(0f, 0f, 0f);
        playerSighted = false;

        lastFrame = lastPlayerSighting.dflt;
        lastPersonalSighting = lastPlayerSighting.dflt;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPlayerSighting.lastWolfSighting != lastPersonalSighting)
        {
            lastPersonalSighting = lastPlayerSighting.lastWolfSighting;
        }

        lastFrame = lastPlayerSighting.lastWolfSighting;
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject == player)
        {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fov * 0.5f)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position + transform.up / 2, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                    {
                        playerSighted = true;
                        lastPlayerSighting.lastWolfSighting = player.transform.position;
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
        if (other.gameObject == player)
        {
            playerSighted = false;
        }
    }

    public void Reset()
    {
        lastFrame = lastPlayerSighting.dflt;
        lastPersonalSighting = lastPlayerSighting.dflt;
    }
}
