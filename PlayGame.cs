using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	//function to switch to the Main Scene for game play 
	public void Play()
	{
		SceneManager.LoadScene ("MainScene");
	}
}
