using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

	public static Text GameOvertext;

	// Use this for initialization
	void Start () {

		// Set up the reference.
		GameOvertext = GetComponent <Text> ();

		GameOvertext.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
