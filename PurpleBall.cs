/*script is attached to the purpleball object
 * code is the same as in SpecialPaddle.cs
 */


using UnityEngine;
using System.Collections;

public class PurpleBall : MonoBehaviour {

  
    public Rigidbody2D rigidBodyPurple2D;
    public bool isPurple;

    // Use this for initialization
    void Start ()
    {
       isPurple = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPurple)
        {
            // sets purple balls starting position to a random position
            this.transform.position = new Vector3(Random.Range(0.4f, 11.2f), Random.Range(7f, 11.5f), (0f)); // change z axis value to make ball visible

            this.rigidBodyPurple2D.gravityScale = 1; // give ball gravity so that if moves, defaul gravity set to 1 in Unity inspector
            this.rigidBodyPurple2D.velocity = new Vector2(5.2f, 5.2f);
            
            isPurple = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(0.2f, 0.3f);
        this.rigidBodyPurple2D.velocity += tweak;
    }
}
