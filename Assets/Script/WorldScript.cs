using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript {
    private static WorldScript instance;
    private int BULLET_COUNT = 0;
    private int KILL_COUNT = 0;
    private int GAME_SCORE = 0;
    private int CURR_LEVEL = 1;
    private int[] HIGH_SCORE = {20,15,10,8,5};
    private string[] NAMES = {"Johnny","Mia","Tori","James","Sasha"};
    private bool GAME_OVER = false;
    private bool HARD_MODE = false;

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

    public void ResetGameOver()
    {
        GAME_OVER = false;
    }

    public void GameOver()
    {
        GAME_OVER = true;
    }

    public bool IsGameOver()
    {
        return GAME_OVER;
    }

    public string getName(int i)
    {
        return NAMES[i];
    }

    public void setName(int i, string name)
    {
        NAMES[i] = name;
    }

    public int getHighScore(int i)
    {
        
        return HIGH_SCORE[i];
    }

    public void setHighScore(int i, int score)
    {
        HIGH_SCORE[i] = score;
    }

    public bool isHARD()
    {
        return HARD_MODE;
    }

    public void setMode(bool mode)
    {
        HARD_MODE = mode;

    }

}
