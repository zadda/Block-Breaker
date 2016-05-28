﻿using UnityEngine;
using System.Collections;

public class SpecialPaddle : MonoBehaviour
{

    
    private Paddle normalPaddle;
  
    private bool isRed = false;
    
   

    // Use this for initialization
    void Start()
    {
        isRed = (this.tag == "Rood");
        normalPaddle = GameObject.FindObjectOfType<Paddle>();
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (isRed)
        {
            Destroy(gameObject);
            Vector3 paddlePos = new Vector3(0f, 500f, 0f);

            normalPaddle.transform.position = paddlePos;
            isRed = false;
        }
    }

    void Update()
    {
        if (!isRed)
        {
            MoveMouse();
        }
    }

    void MoveMouse()
    {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        //verander positie van de paddle

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        // this is de paddle script de component zelf
        this.transform.position = paddlePos;
    }
}
