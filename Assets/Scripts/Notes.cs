using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // 速度
    protected float speed;
    // ゲームが開始したかどうか
    protected bool isStarted;

    void Start() {
        speed = GameManager.Instance.GetNoteSpeed();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStarted)
        {
            isStarted = true;
        }
        if (isStarted)
        {
            // ノーツを動かす
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
    }
}
