using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public GameObject explode;
    public GameObject bullet;
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

        nextFire = 0 + Random.Range(0, 1);
        time = 20;       
	}
	
	// Update is called once per frame
	void Update () {
        if (ws.GetLevel() >= 3)
        {
            time = Time.timeSinceLevelLoad;
            if (time > nextFire)
            {
                nextFire = nextFire + Random.Range(0f, 30f);

                Instantiate(bullet,
                                trans.position + new Vector3(0, -1f, 0),
                                Quaternion.identity);
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
