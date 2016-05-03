using UnityEngine;
using System.Collections;

public class FetchQuestItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Player> () != null) {
			FetchQuestManager fqm = GameObject.FindObjectOfType<FetchQuestManager>();
			fqm.Collect(this.transform.position);
			Destroy(this.gameObject);
		}
	}
}
