﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadline = -10;

    private AudioSource block;

    // Start is called before the first frame update
    void Start()
    {
        block = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadline)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "CubeTag" || col.gameObject.tag == "GroundTag")
        {
            block.PlayOneShot(block.clip);
        }
    }
}
