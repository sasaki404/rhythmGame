using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static GameManager Instance { get; private set; }
    public const int MAX_SCORE = 1000000;
    protected int songID;
    [SerializeField] protected float noteSpeed;
    protected bool isStarted;
    protected float startTime;
    protected int combo = 0;
    protected int score = 0;
    // 内部的なスコアの理論値
    protected float interTheoryScore = 0f;
    // 内部的なスコア
    protected float tempScore = 0f;
    protected int perfect = 0;
    protected int great = 0;
    protected int near = 0;
    protected int miss = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int GetSongID()
    {
        return songID;
    }

    public void SetSongID(int value)
    {
        songID = value;
    }

    public float GetNoteSpeed()
    {
        return noteSpeed;
    }

    public void SetNoteSpeed(float value)
    {
        noteSpeed = value;
    }

    public bool GetIsStarted()
    {
        return isStarted;
    }

    public void SetIsStarted(bool value)
    {
        isStarted = value;
    }

    public float GetStartTime()
    {
        return startTime;
    }

    public void SetStartTime(float value)
    {
        startTime = value;
    }

    public int GetCombo()
    {
        return combo;
    }

    public void SetCombo(int value)
    {
        combo = value;
    }

    public void AddCombo()
    {
        combo++;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        score = value;
    }

    public float GetTempScore()
    {
        return tempScore;
    }

    public void SetTempScore(float value)
    {
        tempScore = value;
    }

    public void AddTempScore(float value)
    {
        tempScore += value;
    }

    public float GetInterTheoryScore()
    {
        return interTheoryScore;
    }

    public void SetInterTheoryScore(float value)
    {
        interTheoryScore = value;
    }

    public int GetPerfect()
    {
        return perfect;
    }

    public void SetPerfect(int value)
    {
        perfect = value;
    }

    public void AddPerfect()
    {
        perfect++;
    }

    public int GetGreat()
    {
        return great;
    }

    public void SetGreat(int value)
    {
        great = value;
    }

    public void AddGreat()
    {
        great++;
    }

    public int GetNear()
    {
        return near;
    }

    public void SetNear(int value)
    {
        near = value;
    }

    public void AddNear()
    {
        near++;
    }

    public int GetMiss()
    {
        return miss;
    }

    public void SetMiss(int value)
    {
        miss = value;
    }

    public void AddMiss()
    {
        miss++;
    }

}
