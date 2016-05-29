/* script attached to the small paddle and red brick
 * when the red brick is hit normal paddle is moved out of view
 * small paddle in view and controlable by player
 * no time or hit limit, special paddle remains until end of level for now
 */

using UnityEngine;
using System.Collections;


public class SpecialPaddle : MonoBehaviour
{
    public bool specialAutoplay = false;

    private Paddle normalPaddle;
    private Ball ball; //
    private bool isRed = false;
    
   

    // Use this for initialization
    void Start()
    {
        
        isRed = (this.tag == "Rood");
        normalPaddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<Ball>(); //
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
        if (specialAutoplay) // checks boolean set on the object in inspector (Unity)
        {
            ComputerPlay();
        }
        else if (!isRed)
        {
            MoveMouse();
        }
    }

    //player is in control
    void MoveMouse()
    {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        //verander positie van de paddle

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        // this is de paddle script de component zelf
        this.transform.position = paddlePos;
    }

    void ComputerPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;

        //verander positie van de paddle

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        // this is de paddle script de component zelf
        this.transform.position = paddlePos;
    }
}
