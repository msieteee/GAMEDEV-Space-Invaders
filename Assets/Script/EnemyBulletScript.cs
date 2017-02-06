using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

    public GameObject explode;
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
        trans.Translate(new Vector3(0, -5f * Time.deltaTime, 0));

        if (trans.position.y <= -4)
        {
            Destroy(obj);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.name.Contains("EnemyBullet") && !col.gameObject.name.Contains("Boundary")
            && !col.gameObject.name.Contains("Model"))
        {
            Destroy(obj);

            var temp = Instantiate(explode,
                obj.gameObject.transform.position,
                Quaternion.identity);

            Destroy(temp, 0.6f);
        }
    }
}
