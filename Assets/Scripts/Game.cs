using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public int winningScore = 3;
	public enum GameState
	{
		gameOver,
		playing
	}
	public GameState gameState = GameState.playing;

	private int playerOneScore;
	private int playerTwoScore;

	private GameObject hudCanvas;
	private GameObject ball;
	private HUD hud;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball");
		hudCanvas = GameObject.Find ("HUD Canvas");
		hud = hudCanvas.GetComponent<HUD>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckScore ();
		if (Input.GetKeyUp (KeyCode.Space) && gameState == GameState.playing) {
			hud.playAgain.enabled = false;
			ball.GetComponent<Ball> ().LaunchBall ();
		} else if (Input.GetKeyUp (KeyCode.Space) && gameState == GameState.gameOver) {
			StartGame ();
		}
	}

	void CheckScore(){
		if (playerOneScore >= winningScore) {
			PlayerOneWins ();
		} else if (playerTwoScore >= winningScore) {
			PlayerTwoWins ();
		}
	}

	void PlayerOneWins(){
		hud.win1.enabled = true;
		GameOver ();
	}

	void PlayerTwoWins(){
		hud.win2.enabled = true;
		GameOver ();
	}

	void GameOver(){
		hud.playAgain.text = "PRESS SPACEBAR TO START AGAIN";
		gameState = GameState.gameOver;
	}

	void StartGame(){
		playerOneScore = 0;
		playerTwoScore = 0;
		hud.playAgain.text = "PRESS SPACEBAR TO PLAY";
		hud.score1.text = "0";
		hud.score2.text = "0";
		hud.win1.enabled = false;
		hud.win2.enabled = false;
		gameState = GameState.playing;
	}

	public void playerOnePoint(){
		playerOneScore++;
		hud.score1.text = playerOneScore.ToString ();
		hud.playAgain.enabled = true;
	}

	public void playerTwoPoint(){
		playerTwoScore++;
		hud.score2.text = playerTwoScore.ToString ();
		hud.playAgain.enabled = true;
	}

	public void reset(){
		ball.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
		ball.transform.position = new Vector3(0f,0f,0f);
	}
}
