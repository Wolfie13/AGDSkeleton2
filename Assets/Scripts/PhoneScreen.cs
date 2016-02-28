using UnityEngine;
using System.Collections.Generic;

public class PhoneScreen : MonoBehaviour {
	public PhoneMessage messagePrefab;

	// Use this for initialization
	void Start () {
		displayMessage ("Hello, World", Color.blue);
		displayMessage ("Goodbye, Cruel World", Color.red);
		displayMessage ("AGD Spook Skeleton 2\nThe Spookening", Color.blue);
		displayMessage ("#BlameHans\n#BlameWill", Color.red);
		displayMessage ("I'm behind u and very...\nSpoookyyyyyy", Color.grey);
		displayMessage ("MEMES", Color.black);
	}

	// Update is called once per frame
	void Update () {

	}

	LinkedList<PhoneMessage> messages = new LinkedList<PhoneMessage>();

	public void displayMessage(string msg, Color color) {
		PhoneMessage newMessage = Instantiate (messagePrefab) as PhoneMessage;
		newMessage.setText (msg);
		newMessage.setColor (color);
		messages.AddFirst (newMessage);
		positionMessages ();
	}

	public void updateTime(string timeString) {
		TextMesh time = GameObject.Find ("Time") as TextMesh;
		if (time != null) {
			time.text = timeString;
		}
	}

	void positionMessages() {
		float accumulatedHeight = -12.5f;
		LinkedListNode<PhoneMessage> currentNode = messages.First;
		while (currentNode != null) {
			PhoneMessage currentMessage = currentNode.Value;
			currentMessage.transform.parent = this.transform;
			accumulatedHeight += (currentMessage.getHeight() / 2) + 0.1f;
			currentMessage.transform.localPosition = new Vector3(0, accumulatedHeight, -2);
			accumulatedHeight += (currentMessage.getHeight() / 2) + 0.1f;
			Debug.Log(accumulatedHeight);
			currentNode = currentNode.Next;
			if (accumulatedHeight > 12) {
				messages.Remove(currentMessage);
				currentMessage.destroy();
			}
		}
	}
}
