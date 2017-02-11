using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    private WorldScript ws;
    // Use this for initialization
    void Start () {
        ws = WorldScript.getInstance();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGame()
    {
        ws.ResetScore();
        ws.ResetLevel();
        ws.ResetGameOver();
        ws.ResetKills();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadTimeAttack()
    {

    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
