using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupScript : MonoBehaviour
{

    private GameObject obj;
    private Transform trans;
    private WorldScript ws;
    private float boundaryLeft;
    private float boundaryRight;
    private bool GO_RIGHT;
    private float DELAY;

    void Start()
    {
        obj = gameObject;
        trans = transform;
        ws = WorldScript.getInstance();

        boundaryLeft = 1f;
        boundaryRight = 9.5f;
        GO_RIGHT = true;
        DELAY = 0.75f;

        StartCoroutine(MiniPause());

    }

    void Update()
    {
        if(ws.GetKills() % 30 == 0 && ws.GetKills() != 0)
        {
            Destroy(obj);
        }

        if (DELAY <= 0)
        {
            
            if (GO_RIGHT)
            {
                trans.Translate(new Vector3(ws.GetLevel() * 0.005f, 0, 0));
            }
            else
            {
                trans.Translate(new Vector3(-ws.GetLevel() * 0.005f, 0, 0));
            }

            if ((trans.position.x >= boundaryRight) || (trans.position.x <= boundaryLeft))
            {
                GO_RIGHT = !GO_RIGHT;
                trans.Translate(new Vector3(0, -0.5f, 0));
            }

        }
        else
        {
            DELAY -= Time.deltaTime;
        }

    }

    IEnumerator MiniPause()
    {
        yield return new WaitForSeconds(10f);
    }

}
