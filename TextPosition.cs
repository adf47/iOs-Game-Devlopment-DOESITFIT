using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPosition : MonoBehaviour {

	public static int score;        // The player's score.


	public static Text text;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		//score = GetComponent <int> ();

		DontDestroyOnLoad (this);


	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.

		text.text = "Score: " + score;
	}

}
