using UnityEngine;
using System.Collections;
using System.Timers;

public class Special : MonoBehaviour {

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    
    public bool isGreen;

    
    
    private Brick brick;
    private Ball ball; //nog te verplaatsen naar special.cs
    private float teller;
  

    //Use this for initialization

   void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
       
    }

  

    void OnCollisionEnter2D(Collision2D col)
    {
        //isGreen = (this.tag == "Green");
        
          ball.GetComponent<SpriteRenderer>().sprite = ball.ballSprites[0]; // 0 = groen, 1 = rood, 2 = grijs
          isGreen = true;
          Destroy(gameObject);
       

        // Debug.LogError(isGreen);
    }
}