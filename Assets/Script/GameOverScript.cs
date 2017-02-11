using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    private WorldScript ws;
    // Use this for initialization

    void Start ()
    {
        ws = WorldScript.getInstance();
    }
	
	// Update is called once per frame
	void Update () {
        float offsetX = Input.GetAxis("Submit");
        if (offsetX > 0)
        {
            if (ws.GetScore() <= ws.getHighScore(4))
            {
                SceneManager.LoadScene("Menu");
            }
            else
            SceneManager.LoadScene("ScoreInput");
        }

    }
}
