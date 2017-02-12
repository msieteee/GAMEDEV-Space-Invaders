using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public GameObject explode;
    public GameObject bullet;
    public GameObject prompt;
    private GameObject obj;
    private Transform trans;
    private WorldScript ws;
    private bool Cooldown;
    private float nextFire;
    private float time;

    // Use this for initialization
    void Start () {
        obj = gameObject;
        trans = transform;
        ws = WorldScript.getInstance();

        obj.GetComponent<Rigidbody>().constraints =
            RigidbodyConstraints.FreezeAll;

        Cooldown = false;

        nextFire = Random.Range(Time.timeSinceLevelLoad, Time.timeSinceLevelLoad + 20);
        time = 0;       
	}
	
	// Update is called once per frame
	void Update () {
        if (ws.GetLevel() >= 3)
        {
            time = Time.timeSinceLevelLoad;
            if (time > nextFire)
            {
                nextFire = nextFire + Random.Range(time, time + 20);

                Instantiate(bullet,
                                trans.position + new Vector3(0, -1f, 0),
                                Quaternion.identity);
            }
        }

        if (trans.position.y < -0.5f)
        {

            Debug.Log(trans.position.y);
            if (!ws.IsGameOver())
            {
                ws.GameOver();
                Instantiate(prompt,
                new Vector3(0, 6.1f, 24.81724f),
                Quaternion.identity);

                GameObject ship = GameObject.FindGameObjectWithTag("Ship");

                Destroy(GameObject.FindGameObjectWithTag("Ship"));

                var temp = Instantiate(explode,
                ship.transform.position,
                Quaternion.identity);

                Destroy(temp, 0.6f);
            }
        }
    }

    void OnCollisionEnter(Collision collide)
    {
        if (!collide.gameObject.name.Contains("Ship") && !collide.gameObject.name.Contains("EnemyBullet"))
        {
            Destroy(obj);

            ws.AddScore();
            ws.AddKill();

            var temp = Instantiate(explode,
                obj.gameObject.transform.position,
                Quaternion.identity);

            Destroy(temp, 0.6f);
        }

    }
}
