using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BoxTrigger : MonoBehaviour {

    public BoxCollider box;

    private List<GameObject> pack;

    void Start()
    {
        pack = new List<GameObject>();
    }

    void OnTriggerEnter(Collider other)
    {

    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Wolf")
            if (pack.Contains(other.gameObject) == false)
            {
                pack.Add(other.gameObject);
                gameObject.GetComponentInParent<WolfAi>().AddPack(other.gameObject);
            }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wolf")
        {
            gameObject.GetComponentInParent<WolfAi>().RemoveWolf(other.gameObject);
        }
    }
}
