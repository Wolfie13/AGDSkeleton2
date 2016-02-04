using UnityEngine;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour {

	private List<Item> items = new List<Item>();
	int selectedItem;

	public GameObject weaponAttachPoint;

	// Use this for initialization
	void Start () {
	
	}

	void SelectItem(int num) {
		if (items.Count > num) {
			items[selectedItem].gameObject.SetActive(false);
			selectedItem = num;
			items[selectedItem].gameObject.SetActive(true);
		}
	}

	void CollectItem(Item i)
	{
		i.transform.parent = this.weaponAttachPoint.transform;
		i.transform.forward = -this.weaponAttachPoint.transform.right;
		i.transform.localPosition = Vector3.zero;
		//Disable collision with the collected item.
		foreach(Collider c in i.GetComponents<Collider> ()) {
			c.enabled = false;
		}
		items.Add (i);
		SelectItem (items.Count - 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if (items.Count > selectedItem) {
				items[selectedItem].Fire(this);
			}
		}

		Item[] pickups = GameObject.FindObjectsOfType<Item> ();
		foreach (Item i in pickups) {
			if (i.transform.parent == this.weaponAttachPoint.transform) {
				continue;
			}

			if (Vector3.Distance(i.transform.position, this.transform.position) < 2) {
				CollectItem(i);
			}
		}

		//Check all the number keys on the keyboard.
		for ( int i = 0; i < 10; ++i )
		{
			if ( Input.GetKeyDown( KeyCode.Alpha1 + i ) )
			{
				SelectItem(i);
			}
		}
	}

}
