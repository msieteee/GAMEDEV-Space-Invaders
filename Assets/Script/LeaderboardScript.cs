using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScript : MonoBehaviour {

    public Text score;

    private WorldScript ws;
    // Use this for initialization
    void Start () {
        ws = WorldScript.getInstance();
        score.text = "";
        for (int i = 0; i < 5; i++)
        {
            score.text += ws.getName(i)+" : "+ws.getHighScore(i)+"\n";
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
