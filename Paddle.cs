/*script is attached to the regular paddle
 * code is the same as in SpecialPaddle.cs
 */


using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;
    


    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        
    }

	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            computerPlay();
        }
	}

    void MoveWithMouse()
    {

            Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
            float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

            //verander positie van de paddle

            paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
            // this is de paddle script de component zelf
            this.transform.position = paddlePos;
       
    }

     void computerPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;

        //verander positie van de paddle

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        // this is de paddle script de component zelf
        this.transform.position = paddlePos;
    }

}
