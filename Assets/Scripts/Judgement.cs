using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Score : int
{
    perfect = 4,
    great = 2,
    near = 1,
    miss = 0
}

// 判定やスコアの加算を行うクラス
public class Judgement : MonoBehaviour
{
    [SerializeField] private MusicalScoreManager musicalScoreManager;
    [SerializeField] private GameObject[] messageObjects;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip tapSound;

    void Update()
    {
        if (!GameManager.Instance.GetIsStarted())
        {
            return;
        }
        if (musicalScoreManager.notesTimes.Count <= 0)
        { // 処理するノーツがないとき
            return;
        }
        float tmpTime = musicalScoreManager.notesTimes[0];
        float diff = Math.Abs(Time.time - tmpTime - GameManager.Instance.GetStartTime());
        switch (musicalScoreManager.notesLaneNums[0])
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    judge(diff);
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    judge(diff);
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    judge(diff);
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    judge(diff);
                }
                break;
            default:
                break;
        }
        if (Time.time - tmpTime - GameManager.Instance.GetStartTime() > 0.25f) // ノーツが判定ラインを過ぎてから0.25秒以上経過したとき
        {
            Debug.Log("Miss");
            displayMessage(3);
            updateNotes();
            GameManager.Instance.AddMiss();
            // GameManager.Instance.AddTempScore((float)Score.miss);
            GameManager.Instance.SetCombo(0);
        }
    }

    // 判定する
    void judge(float diff)
    {
        if (diff > 0.25)
        {
            return;
        }

        AudioManager.audioSource.PlayOneShot(tapSound);
        GameManager.Instance.AddCombo();

        if (diff <= 0.10)
        {
            Debug.Log("Perfect");
            displayMessage(0);
            updateNotes();
            GameManager.Instance.AddPerfect();
            GameManager.Instance.AddTempScore((float)Score.perfect);
        }
        else if (diff <= 0.15)
        {
            Debug.Log("Great");
            displayMessage(1);
            updateNotes();
            GameManager.Instance.AddGreat();
            GameManager.Instance.AddTempScore((float)Score.great);
        }
        else if (diff <= 0.25)
        {
            Debug.Log("Near");
            displayMessage(2);
            updateNotes();
            GameManager.Instance.AddNear();
            GameManager.Instance.AddTempScore((float)Score.near);
        }
    }

    // ノーツとスコアを更新
    void updateNotes()
    {
        musicalScoreManager.notesTimes.RemoveAt(0);
        musicalScoreManager.notesLaneNums.RemoveAt(0);
        musicalScoreManager.notesTypes.RemoveAt(0);
        GameManager.Instance.SetScore((int)(GameManager.MAX_SCORE * GameManager.Instance.GetTempScore() / GameManager.Instance.GetInterTheoryScore()));
    }

    // メッセージを表示する
    void displayMessage(int judge)
    {
        Instantiate(messageObjects[judge], new Vector3(musicalScoreManager.notesLaneNums[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
        comboText.text = GameManager.Instance.GetCombo().ToString();
        scoreText.text = GameManager.Instance.GetScore().ToString();
    }
}
