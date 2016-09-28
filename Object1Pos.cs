using UnityEngine;
using System.Collections;

public class Object1Pos : MonoBehaviour {

	public GameObject obj2; //to get object to make them to be equal distances apart

	// Use this for initialization
	void Start () {
	
		float x;

		Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0)); //gets the width of the screen in demensions
		float Scr = screen.x - 0.80F;
		print ("Bottom number "+screen.x);
		Vector3 pos;

		x = Random.Range(-Scr, -0.5F);

		pos = new Vector3(x, -3, 1);

		// make it a child of the current object
		transform.parent = Camera.main.transform; 
		transform.localPosition = pos;


		float Secx = x * -1F; //to make obj 2 symmetric

		Vector3 pos2;

		pos2 = new Vector3 (Secx,-3,1);

		obj2.transform.parent = Camera.main.transform;

		obj2.transform.localPosition = pos2;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
