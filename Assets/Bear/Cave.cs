using UnityEngine;
using System.Collections;

public class Cave : MonoBehaviour 
{

    public SphereCollider col;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<BearAi>().Alert(other.gameObject.transform.position);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<BearAi>().Return();
        }
    }
}
