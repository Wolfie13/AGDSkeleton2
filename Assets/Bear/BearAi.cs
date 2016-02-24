using UnityEngine;
using System.Collections;

public class BearAi : MonoBehaviour {

    public BearSight sight;
    public GameObject cave;

    [SerializeField(), Range(0f, 10f)]
    private float chasespeed = 5f;
    [SerializeField(), Range(0f, 10f)]
    private float roamspeed = 3f;
    [SerializeField(), Range(0f, 10f)]
    private float chaseWait = 5f;

    private float chaseTime;
    private float roamTime;
    private NavMeshAgent nav;
    private Vector3 roamTarget;
    private GameObject player;
    

    void Start()
    {
        sight = gameObject.GetComponent<BearSight>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.stoppingDistance = 2;
        player = GameObject.FindGameObjectWithTag("Player");
        roamTarget = new Vector3(0f, 0f, 0f);
        roamTarget = GeneratePos();
        nav.SetDestination(roamTarget);
        nav.speed = roamspeed;
    }


    void Update()
    {
        if (sight.playerSighted == false)
        {
            //roam
            if (nav.remainingDistance < nav.stoppingDistance || transform.position == nav.destination)
            {
                Roam();
            }

        }
    }

    void Chasing()
    {
        Vector3 toPlayer = sight.lastPersonalSighting - transform.position;

        if (toPlayer.sqrMagnitude > 4f)
        {
            nav.destination = sight.lastPersonalSighting;
        }

        nav.speed = chasespeed;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            chaseTime += Time.deltaTime;

            if (chaseTime >= chaseWait)
            {
                sight.Reset();
            }
        }
        else
        {
            chaseTime = 0f;
        }
    }
    Vector3 GeneratePos()
    {
        float minX = cave.transform.position.x - 20;
        float maxX = cave.transform.position.x + 20;
        float minZ = cave.transform.position.z - 20;
        float maxZ = cave.transform.position.z + 20;

        Vector3 newVec = new Vector3(Random.Range(minX, maxX), gameObject.transform.position.y, Random.Range(minZ, maxZ));

        return newVec;
    }
    void Roam()
    {
        roamTarget = GeneratePos();
        nav.SetDestination(roamTarget);
    }
    void Return()
    {
        Debug.Log("Return");
        nav.SetDestination(cave.transform.position);
    }

    public void Attack()
    {
        nav.Stop();
    }
    public void StopAttack()
    {
        nav.Resume();
    }
}
