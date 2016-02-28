using UnityEngine;
using System.Collections;

public class Fear : MonoBehaviour {

    public float fear;

    public float fearWait = 10;
    public float fearTime;
	// Use this for initialization
	void Start () 
    {
        fear = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (fearTime > fearWait)
        {
            fear += 10;
            fearTime = 0;
        }
        fearTime++;
	}

    public void Reduce()
    {
        fear -= 10;
    }
}
