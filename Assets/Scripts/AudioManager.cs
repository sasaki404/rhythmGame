using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    // 楽曲ディレクトリ名
    const string MUSIC_DIR = "Musics";
    public static AudioSource audioSource;
    protected AudioClip audioClip;
    protected string musicName;
    protected bool isPlayed;

    void Start()
    {
        musicName = "シカ色デイズ";
        audioSource = GetComponent<AudioSource>();
        audioClip = (AudioClip)Resources.Load(MUSIC_DIR + "/" + musicName);
        isPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlayed)
        {
            audioSource.PlayOneShot(audioClip);
            GameManager.Instance.SetStartTime(Time.time);
            GameManager.Instance.SetIsStarted(true);
            isPlayed = true;
        }
    }
}
