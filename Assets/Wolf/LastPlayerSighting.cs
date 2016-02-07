using UnityEngine;
using System.Collections;

public class LastPlayerSighting : MonoBehaviour {

    public Vector3 dflt;

    public Vector3 lastWolfSighting;
    public Vector3 lastBearSighting;
    public Vector3 lastGhostSighting;
    void Start()
    {
        dflt = new Vector3(0f, 0f, 0f);
        lastWolfSighting = new Vector3(0f, 0f, 0f);
        lastBearSighting = new Vector3(0f, 0f, 0f);
        lastGhostSighting = new Vector3(0f, 0f, 0f);
    }
    public void Sighted(GameObject receiver)
    {
        if(receiver.tag == "Wolf")
        {
            receiver.gameObject.GetComponent<Sight>().packSighted = true;
            
        }
    }
}
