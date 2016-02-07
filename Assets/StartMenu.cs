using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Button playGame;
	public Button exitGame;

	public Camera menuCamera;
	// Use this for initialization
	void Start () {
		playGame = playGame.GetComponent<Button> ();
		exitGame = exitGame.GetComponent<Button> ();
	}

	public void StartLevel()
	{
		Application.LoadLevel ("AGDLevel");
	}

	public void ExitLevel()
	{
		Application.Quit ();
	}
}
