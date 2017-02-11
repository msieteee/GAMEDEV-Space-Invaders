using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {
    public Text score;
    public InputField input;
    private WorldScript ws;
    private int place;
    // Use this for initialization
    void Start ()
    {

        ws = WorldScript.getInstance();
        for (int i = 4; i>=0; i--)
        {
            if (ws.GetScore() > ws.getHighScore(i))
            {
                place = i;
            }
        };
        score.text = "Score : "+ ws.GetScore();
        input.text = "Player";
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SaveScore()
    {
        if(input.text!="")
        {
            for(int i=4; i>place; i--)
            {
                ws.setName(i, ws.getName(i-1));
                ws.setHighScore(i, ws.getHighScore(i-1));
            }
            ws.setName(place, input.text);
            ws.setHighScore(place, ws.GetScore());
            SceneManager.LoadScene("Menu");
        }
    }
}
