using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject obj;
    private Transform trans;
    private WorldScript ws;

    void Start()
    {
        obj = gameObject;
        trans = transform;
        ws = WorldScript.getInstance();     
    }

    void Update()
    {
        trans.Translate(new Vector3(0, 10f * Time.deltaTime, 0));

        if (trans.position.y >= 8.3)
        {
            ws.DeleteBullet();
            Destroy(obj);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.name.Contains("Bullet") && !col.gameObject.name.Contains("Boundary")
            || col.gameObject.name.Contains("EnemyBullet"))
        {
            ws.DeleteBullet();
            Destroy(obj);
        }
    }
}
