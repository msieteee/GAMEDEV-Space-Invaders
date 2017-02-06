using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public GameObject prompt;
    private GameObject obj;
    private Transform trans;
    private WorldScript ws;

    // Use this for initialization
    void Start () {
        obj = gameObject;
        ws = WorldScript.getInstance();
	}
	
	// Update is called once per frame
	void Update () {
        obj.GetComponent<TextMesh>().text = "SCORE: " + ws.GetScore();

        if(ws.GetKills() != 0 && ws.GetKills() % 30 == 0)
        {
            ws.ResetKills();
            Invoke("AddPrompt", 1f);
        }
    }

    void AddPrompt()
    {
        Instantiate(prompt,
                new Vector3(-12.66f, 4.1f, 24.81724f),
                Quaternion.identity);
    }
}
