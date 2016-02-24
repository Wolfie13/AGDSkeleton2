using UnityEngine;
using System.Collections;

public class BearCapsuleTrigger : MonoBehaviour 
{
    public CapsuleCollider cap;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<BearAi>().Attack();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<BearAi>().StopAttack();
        }
    }

}
