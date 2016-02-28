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
    [SerializeField(), Range(0f, 10f)]
    private float AlertWait = 5f;

    private float chaseTime;
    private float roamTime;
    private float alertTime;
    private NavMeshAgent nav;
    private Vector3 roamTarget;
    private GameObject player;
    private bool alert = false;
    

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
        if (alert)
        {
            alertTime += Time.deltaTime;
            if (alertTime > AlertWait)
            {
                Return();
                alertTime = 0;
                alert = false;
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

        alert = false;
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
    public void Return()
    {
        Debug.Log("Return");
        nav.SetDestination(cave.transform.position);
    }

    public void Alert(Vector3 pos)
    {
        nav.Stop();
        nav.SetDestination(pos);
        alert = true;
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
