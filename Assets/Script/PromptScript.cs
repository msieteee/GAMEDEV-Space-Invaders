using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour {

    public GameObject enemy;
    private GameObject obj;
    private WorldScript ws;
    private bool Cooldown;

	// Use this for initialization
	void Start () {
        obj = gameObject;
        ws = WorldScript.getInstance();
        Cooldown = false;
	}
	
	// Update is called once per frame
	void Update () {
        float offsetX = Input.GetAxis("Submit");

        if(offsetX > 0 && !Cooldown)
        {
            ws.AddLevel();
            Cooldown = true;
            Debug.Log("Current level: " + ws.GetLevel());
            Invoke("SpawnEnemy", 0.2f);
            Destroy(obj, 0.2f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy,
                new Vector3(5.26f, 0.89f, 12.44092f),
                Quaternion.identity);
        Instantiate(enemy,
                new Vector3(5.26f, -0.11f, 12.44092f),
                Quaternion.identity);
        Instantiate(enemy,
                new Vector3(5.26f, -1.11f, 12.44092f),
                Quaternion.identity);
    }
}
