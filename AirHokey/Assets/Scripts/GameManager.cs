using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int PlayerScore1 = 0;
	public int PlayerScore2 = 0;
	private int total = 3;
	private AudioSource scoreSound;

	public GUISkin layout;
	GameObject theBall;
	private bool p1 = false;
	private bool p2 = false;
	
	public void Score (string wallID) {
	    if (wallID == "wallR")
	    {
        	PlayerScore1++;
			scoreSound.Play();
	    }else{
	        PlayerScore2++;
			scoreSound.Play();
	    }
	}

	void showPlacar(){
		GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
	    GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
	}

	private void RestartBalls()
    {
        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }

	private void zerarPontos(){
		PlayerScore1 = 0;
		PlayerScore2 = 0;
	}

	void OnGUI () {
	    GUI.skin = layout;
	    showPlacar();

	    if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
	    {
	        zerarPontos();
	        RestartBalls();
	    }
	    if (PlayerScore1 == total){
			p1 = true;
			Invoke("timer", 2);

			zerarPontos();
			RestartBalls();
	    } else if (PlayerScore2 == total){
			p2 = true;
			Invoke("timer", 2);

			zerarPontos();
			RestartBalls();
	    }

		if(p1){
			GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
		}
		if(p2){
			GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
		}
	}

	public void timer(){
		p1 = false;
		p2 = false;
	}

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("TagBall");
		scoreSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
