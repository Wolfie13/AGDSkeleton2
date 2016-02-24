using UnityEngine;
using System.Collections;

public class BearCapsuleTrigger : MonoBehaviour 
{
    public CapsuleCollider cap;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

}
