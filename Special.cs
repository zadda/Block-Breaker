using UnityEngine;
using System.Collections;
using System.Timers;

public class Special : MonoBehaviour {

    
    private LevelManager levelManager;
    private Brick brick;
    private Ball ball; 

    public bool isGreen;

    private int timesHit;
    private float teller;
    //Use this for initialization

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
          ball.GetComponent<SpriteRenderer>().sprite = ball.ballSprites[0]; // 0 = groen, 1 = rood, 2 = grijs
          isGreen = true;
          Destroy(gameObject);
    }
}