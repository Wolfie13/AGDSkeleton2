using UnityEngine;
using System.Collections;

public class CapsuleTrigger : MonoBehaviour 
{
    public CapsuleCollider cap;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<WolfAi>().Attack();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<WolfAi>().StopAttack();
        }
    }

}
