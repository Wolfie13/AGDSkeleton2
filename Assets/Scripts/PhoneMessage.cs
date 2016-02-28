using UnityEngine;
using System.Collections;

public class PhoneMessage : MonoBehaviour {
	public TextMesh messageText;
	public GameObject background;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void destroy() {
		Destroy (messageText);
		Destroy (background);
		Destroy (this);
	}

	public float getHeight() {
		return background.renderer.bounds.extents.y * 2.0f;
	}

	public void setColor(Color c) {
		Material mat = Instantiate (this.background.renderer.material) as Material;
		mat.color = c;
		this.background.renderer.material = mat;
	}

	public void setText(string s) {
		messageText.text = s;
		//Scale the text horizontally so it fits the screen.
		{
			float targetWidth = background.renderer.bounds.extents.x;
			float currentWidth = messageText.renderer.bounds.extents.x;
			float factor = messageText.transform.localScale.x * (targetWidth / currentWidth);
			messageText.transform.localScale = new Vector3 (factor, factor, 1);
		}

		//Scale the message background vertically so it fits the text.
		{
			float targetHeight = messageText.renderer.bounds.extents.y;
			float currentHeight = background.renderer.bounds.extents.y;
			float factor = background.transform.localScale.y * (targetHeight / currentHeight);
			background.transform.localScale = new Vector3 (background.transform.localScale.x, factor, 1);
		}
	}
}
