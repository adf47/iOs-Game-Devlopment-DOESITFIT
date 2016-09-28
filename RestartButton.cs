using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	
	// Update is called once per frame
	public void Clicked () {

		if (BallBehavior.AdClicked == false) {
			
			TextPosition.score = 0;
			BallBehavior.OneGame = false;

		} else if(BallBehavior.AdClicked == true){
			BallBehavior.OneGame = true;
		}
		SceneManager.LoadScene ("MainScene");

	}

}
