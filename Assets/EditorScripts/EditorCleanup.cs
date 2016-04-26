using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorCleanup : UnityEditor.EditorWindow {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[MenuItem("Window/Cleanup")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(EditorCleanup));
	}

	void OnGUI()
	{
		if (GUILayout.Button ("Clean Up")) {
			GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
			foreach (GameObject g in objects) {
				if (g.name.Contains("pCube"))
				{
					if (g.transform.childCount == 0)
					{
						Debug.Log(g.name + " " + g.GetComponents<Component>().Length);
						if (g.GetComponents<Component>().Length == 1) {
							//DestroyImmediate(g);
						}
					}
				}
			}
		}
	}

}
