using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {

	public static int Highscore;        // The player's score.


	public static Text text2;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		text2 = GetComponent <Text> ();

		text2.text = "";

		DontDestroyOnLoad (this);


	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
	}

}
