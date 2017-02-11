using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour {

    public GameObject bullet;
    public GameObject explode;
    public GameObject prompt;
    private GameObject obj;
    private Transform trans;
    private WorldScript ws;
    private bool Cooldown;

    void Start()
    {
        obj = gameObject;
        trans = transform;
        ws = WorldScript.getInstance();
        Cooldown = false;
    }   

    void Update()
    {
        float offsetX = Input.GetAxis("Horizontal");
        if (offsetX > 0 && trans.localPosition.x < 8.2)
        {
            trans.Translate(offsetX * 0.25f, 0, 0);
        }
        else if (offsetX < 0 && trans.localPosition.x > -8.2)
        {
            trans.Translate(offsetX * 0.25f, 0, 0);
        }

        float fire = Input.GetAxis("Vertical");
        if (fire < 0)
        { 
            if (!Cooldown)
            {
                if (ws.GetBulletCount() < 3)
                {
                    ws.AddBullet();
                    Instantiate(bullet,
                        trans.position + new Vector3(0, 1f, 0),
                        Quaternion.identity);
                    Cooldown = true;
                    Invoke("ResetCooldown", 0.2f);
                }
            }
        }
        
    }

    void ResetCooldown()
    {
        Cooldown = false;
    }

    void OnCollisionEnter(Collision collide)
    {
        Destroy(obj);

        Instantiate(prompt,
            new Vector3(0, 4.1f, 24.81724f),
            Quaternion.identity);

        var temp = Instantiate(explode,
            obj.gameObject.transform.position,
            Quaternion.identity);

        Destroy(temp, 0.6f);
    }
}
