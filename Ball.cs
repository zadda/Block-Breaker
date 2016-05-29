/* script attached to the regular ball object
 * if game hasn't started the ball is fixed on the paddle
 * script execution is set for order of scripts
 * when player clicks ball is launched
 * on collision speed is adjusted * 
 */


using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    
    public Rigidbody2D rigidBody2D; // zorgt ervoor dat er in de scripts sectie een veld vrijkomt waar het rigidbody 2D object van bal naartoe gesleept moet worden
    public Sprite[] ballSprites;

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasGameStarted = false;

	// Use this for initialization
	void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;      
        //Debug.Log(paddleToBallVector);        
    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f)) ;
        this.GetComponent<Rigidbody2D>().velocity += tweak;
    }


	// Update is called once per frame
    // check of er op de muis is geklikt, ja? -> lanceer bal, nee -> bal blijft gefixeerd op paddle
	void Update ()
    {
        if (!hasGameStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector; // zorgt ervoor dat de bal op de paddle blijft relative positie

            if (Input.GetMouseButtonDown(0))
            {
                hasGameStarted = true;
                this.rigidBody2D.velocity = new Vector2(2f, 10f);      // this == ball, lanceert ball
            }
        }      
   	}
}
