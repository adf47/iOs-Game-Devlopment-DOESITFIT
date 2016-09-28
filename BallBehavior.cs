using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour {

	public GameObject RestartBut;
	public GameObject AdBut;

	//for sound affects
	private AudioSource source;
	public AudioClip LostSound;
	float vol = 0.7F;

	private bool hit1 = false;
	private bool hit2 = false;
	private bool hit3 = false;
	private bool ScreenTouched = false;
	private bool canTouch;

	//For advertisements
	public static bool AdClicked = false;
	public static bool OneGame = false;
	private bool ObjectHit = false;

	//Sprites to load in
	public Sprite WhiteBall;
	public Sprite poly;
	public Sprite rect;

	int HighScore = 0; //high score var

	private Rigidbody2D rigid;



	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource>();

		//setting up the score
		if (!AdClicked && ObjectHit) {

			//restart score
			TextPosition.score = 0;
			ObjectHit = false;
			OneGame = false; //to show ad button again
			print(OneGame);

		} else if(ObjectHit && AdClicked){ //reset bools for ads

			ObjectHit = false;
			AdClicked = false;
			OneGame = true;
		}

		AdClicked = false;
		ObjectHit = false;

		//getting the high score
		HighScore = PlayerPrefs.GetInt("highScore");

		//Array that holds the images
		Sprite [] sprites = {WhiteBall,poly,rect};
		//print (sprites[1]);

		//Get the rigidbody of character
		rigid = GetComponent<Rigidbody2D>();

		//loading in random character design after each point
		int x = Random.Range(0,2);

		gameObject.GetComponent<SpriteRenderer> ().sprite = sprites[x];

		PolygonCollider2D boxCollider = gameObject.AddComponent<PolygonCollider2D>();

		canTouch = true;
		ScreenTouched = false;

		hit1 = false;
		hit2 = false;
		hit3 = false;

		//setting timescale to normal
		Time.timeScale = 1;

		//hiding buttons
		RestartBut.gameObject.SetActive(false);
		AdBut.gameObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		for(int i = 0; i < Input.touchCount; i++)
		{
			//when user holds in the screen-- Makes object get larger
			if (canTouch) {
				transform.localScale += new Vector3 (0.01F, 0.01F, 0.01F);
			}

			ScreenTouched = true;
		}

		if(ScreenTouched && Input.touchCount == 0){

			rigid.gravityScale = 1;

			canTouch = false;
		}

	}


	void OnCollisionEnter2D(Collision2D hit)
	{

		if (hit.transform.gameObject.name == "Object1") {

			hit1 = true;

		}

		if(hit.transform.gameObject.name =="Object2"){

			hit2 = true;
		}

		if(hit.transform.gameObject.name == "Spike"){

			//Check high score here and update if need be
			hit3 = true;

			//PLay audio for losing
			//source.PlayOneShot(LostSound,vol);

			ObjectHit = true;//for ads to reboot score

			//checking for new high score
			if(TextPosition.score > HighScore) {

				HighScore = TextPosition.score;
				PlayerPrefs.SetInt ("highScore",HighScore);

			}

			//displaying highscore
			//getting the high score
			HighScore = PlayerPrefs.GetInt("highScore");
			HighScoreText.text2.text = "HighScore: " + HighScore;

			//TextPosition.score = 0;

			//Destorying Object
			Destroy(gameObject);

			//You lose animation
			GameOverText.GameOvertext.text = "Game Over!";

			RestartBut.gameObject.SetActive(true);


			if(!OneGame){ //can add other ways to show the ads here.
				AdBut.gameObject.SetActive (true);
			}

			//Pause game -- add buttons to restart or watch ad to continue
			Time.timeScale = 0;

			//SceneManager.LoadScene ("MainScene"); //here go to main menu to start over agai
		}

		if(hit.transform.gameObject.name == "BarrierRight" || hit.transform.gameObject.name == "BarrierLeft"){

			ObjectHit = true; //for ads to rebot score

			//PLay audio for losing
			//source.clip = LostSound;
			//source.Play();

			//Check high score here and update if need be
			//checking for new high score
			if(TextPosition.score > HighScore) {

				HighScore = TextPosition.score;
				PlayerPrefs.SetInt ("highScore",HighScore);

			}

			//displaying highscore
			//getting the high score
			HighScore = PlayerPrefs.GetInt("highScore");
			HighScoreText.text2.text = "HighScore: " + HighScore;

			//TextPosition.score = 0;

			//Destroying object
			Destroy(gameObject);

			//You lose animation
			GameOverText.GameOvertext.text = "Game Over!";

			RestartBut.gameObject.SetActive (true);

			if(!OneGame){
				AdBut.gameObject.SetActive (true);
			}


			//Pause game -- add buttons to restart or watch ad to continue
			Time.timeScale = 0;

			//SceneManager.LoadScene ("MainScene"); //here go to main menu to start over again
		}

		if (hit1 && hit2 && !hit3) { //good play, update score here

			print ("Collision Occured");

			GameOverText.GameOvertext.text = "";

			++TextPosition.score;

			SceneManager.LoadScene ("MainScene"); //restarts the level after a good point


		}

	}

	public void Restart(){

		ScreenTouched = false;
		rigid.gravityScale = 0;
		SceneManager.LoadScene ("MainScene"); //restarts the level after a good point
		ScreenTouched = false;
	}

}
