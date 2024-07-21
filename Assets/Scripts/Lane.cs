using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // レーンのID
    [SerializeField] protected int id = 0;
    // 入力時の表示速度
    [SerializeField] protected float speed = 3;
    // 不透明度
    protected float alpha = 0;
    // レンダラー
    protected new Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color temp = renderer.material.color;
        renderer.material.color = new Color(temp.r, temp.g, temp.b, alpha);
        switch (id)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    onKeyDown();
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    onKeyDown();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    onKeyDown();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    onKeyDown();
                }
                break;
            default:
                break;
        }
        alpha -= speed * Time.deltaTime;
    }

    void onKeyDown()
    {
        alpha = 0.5f;
        Color temp = renderer.material.color;
        renderer.material.color = new Color(temp.r, temp.g, temp.b, alpha);
    }
}
