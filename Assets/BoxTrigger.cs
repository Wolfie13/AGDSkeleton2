using UnityEngine;
using System.Collections;

public class BoxTrigger : MonoBehaviour {

    public BoxCollider box;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wolf")
        {
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
