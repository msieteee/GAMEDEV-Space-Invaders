using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript {
    private static WorldScript instance;
    private int BULLET_COUNT = 0;
    private int KILL_COUNT = 0;
    private int GAME_SCORE = 0;
    private int CURR_LEVEL = 1;
    private int[] HIGH_SCORE = new int[5];

    public static WorldScript getInstance()
    {
        if (instance == null)
        {
            instance = new WorldScript();
        }

        return instance;
    }

    public void AddBullet()
    {
        BULLET_COUNT++;
    }

    public void DeleteBullet()
    {
        BULLET_COUNT--;
    }

    public int GetBulletCount()
    {
        return BULLET_COUNT;
    }

    public void AddScore()
    {
        GAME_SCORE++;
    }

    public void ResetScore()
    {
        GAME_SCORE = 0;
    }

    public int GetScore()
    {
        return GAME_SCORE;
    }

    public void AddKill()
    {
        KILL_COUNT++;
    }

    public void ResetKills()
    {
        KILL_COUNT = 0;
    }

    public int GetKills()
    {
        return KILL_COUNT;
    }

    public void AddLevel()
    {
        CURR_LEVEL += 1;
    }

    public void ResetLevel()
    {
        CURR_LEVEL = 1;
    }

    public int GetLevel()
    {
        return CURR_LEVEL;
    }
}
