using UnityEngine;
using System.Collections;

public class Object2Pos : MonoBehaviour {

	// Use this for initialization
	void Start () {

		float x;

		Vector3 pos;

		x = Random.Range(1.20F, 3.15F);

		pos = new Vector3(x, 0, 0);
		transform.position = pos;

	}

	// Update is called once per frame
	void Update () {

	}

}
