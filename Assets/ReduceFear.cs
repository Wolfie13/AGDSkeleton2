using UnityEngine;
using System.Collections;

public class ReduceFear : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<Fear>().Reduce();
        }
    }
}
