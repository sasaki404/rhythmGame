using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// ノーツ
[Serializable]
public struct Note
{
    // 1拍のライン数
    public int LPB;
    // 
    public int num;
    // 配置するレーン
    public int block;
    // 種類 TODO: enum作成
    public int type;
}

// 譜面情報
[Serializable]
public struct ScoreInfo
{
    // 楽曲名
    public string name;
    // レーンの数
    public int maxBlock;
    // BPM
    public int BPM;
    // オフセット
    public float offset;
    // ノーツのリスト
    public Note[] notes;
}

// 譜面の管理クラス
public class MusicalScoreManager : MonoBehaviour
{
    // Notesオブジェクト
    [SerializeField] protected GameObject notesObject;
    // ノーツの速度
    protected float noteSpeed;
    // 譜面情報ファイル名
    protected string fileName;
    // 総ノーツ数
    protected int noteNum;
    // BPM 60秒あたりの拍数
    protected int bpm;
    // LPB 1拍の分割数
    protected int lpb;
    // 各ノーツのレーン番号のリスト
    public List<int> notesLaneNums;
    // 各ノーツが判定ラインに重なる時間のリスト
    public List<float> notesTimes;
    // 各ノーツの種類のリスト
    public List<int> notesTypes;

    void Start()
    {
        initialize();
        loadMusicalScoreFile(fileName);
    }

    // 初期化処理を行う
    protected void initialize()
    {
        noteSpeed = GameManager.Instance.GetNoteSpeed();
        noteNum = 0;
        // TODO: 仮
        fileName = "シカ色デイズ";
    }

    // 譜面情報ファイルを読み込む
    protected void loadMusicalScoreFile(String name)
    {
        string jsonStr = Resources.Load<TextAsset>(name).ToString();
        ScoreInfo scoreInfo = JsonUtility.FromJson<ScoreInfo>(jsonStr);
        updateForScoreInfo(scoreInfo);
        generateNotes(scoreInfo.notes, scoreInfo.offset);
    }

    // 譜面情報からフィールドを更新する
    protected void updateForScoreInfo(ScoreInfo scoreInfo)
    {
        noteNum = scoreInfo.notes.Length;
        bpm = scoreInfo.BPM;
        if (noteNum > 0)
        {
            lpb = scoreInfo.notes[0].LPB;
            GameManager.Instance.SetInterTheoryScore(noteNum * (int)Score.perfect);
        }
    }

    // ノーツを生成する（BPMやノーツ数はメンバ変数を参照）
    protected void generateNotes(Note[] notesList, float offset)
    {
        // 1拍当たりの秒数
        float secPerBeat = 60f / bpm;
        // NoteEditor上の縦線の間隔
        float interval = secPerBeat / lpb;
        for (int i = 0; i < noteNum; i++)
        {
            Note note = notesList[i];
            notesLaneNums.Add(note.block);
            notesTypes.Add(note.type);
            // ノーツがラインに重なる時間
            float time = (note.num * interval) + offset * 0.01f;
            notesTimes.Add(time);
            Instantiate(notesObject, new Vector3(note.block - 1.5f, 0.5f, time * noteSpeed), Quaternion.identity);
        }
    }
}
