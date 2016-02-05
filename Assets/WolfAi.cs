using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolfAi : MonoBehaviour
{

    public Sight sight;
    public int packsize = 15;

    [SerializeField(), Range(0f, 10f)]
    private float chasespeed = 5f;
    [SerializeField(), Range(0f, 10f)]
    private float roamspeed = 3f;
    [SerializeField(), Range(0f, 10f)]
    private float chaseWait = 5f;
    [SerializeField(), Range(0f, 10f)]
    private float packChaseWait = 5f;

    private float chaseTime;
    private float roamTime;
    private float packChaseTime;
    private List<GameObject> pack;
    private NavMeshAgent nav;
    private Vector3 roamTarget;
    private GameObject player;

    void Start()
    {
        pack = new List<GameObject>();
        sight = gameObject.GetComponent<Sight>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        roamTarget = new Vector3(0f, 0f, 0f);
        roamTarget = GeneratePos();
    }


    void Update()
    {
        if (sight.playerSighted)
        {
            if (pack.Count > 3)
            {
                sight.AlertPack(pack);
                //chase
                Chasing();
            }
            else
            {
                Flee();
            }
        }
        if (sight.playerSighted == false && sight.packSighted == true)
        {
            //follow pack
            Chasing();
            packChaseTime += Time.deltaTime;
            if(packChaseTime >= packChaseWait)
            {
                //stop chase
                sight.packSighted = false;
                packChaseTime = 0f;
            }

        }
        if (sight.packSighted == false && sight.playerSighted == false)
        {
            //roam
            Roam();
        }
    }

    void Chasing()
    {
        Vector3 toPlayer = sight.lastPersonalSighting - transform.position;

        if(toPlayer.sqrMagnitude > 4f)
        {
            nav.destination = sight.lastPersonalSighting;
        }

        nav.speed = chasespeed;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            chaseTime += Time.deltaTime;

            if (chaseTime >= chaseWait && sight.packSighted == false)
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
        float minX = transform.position.x - 10;
        float minZ = transform.position.z - 10;

        Vector3 newVec = new Vector3(Random.Range(minX, -minX), gameObject.transform.position.y, Random.Range(minZ, -minZ));

        return newVec;
    }
    void Roam()
    {
        nav.speed = roamspeed;
        nav.SetDestination(roamTarget);

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            roamTarget = GeneratePos();
        }

    }
    void Flee()
    {

    }

    public void Attack()
    {
        nav.Stop();
    }
    public void StopAttack()
    {
        nav.Resume();
    }
    public void AddPack(GameObject wolf)
    {
        pack.Add(wolf);
    }
    public void RemoveWolf(GameObject wolf)
    {
        if (pack.Contains(wolf))
        {
            pack.Remove(wolf);
        }
    }
}
