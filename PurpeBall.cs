using UnityEngine;
using System.Collections;

public class PurpeBall : MonoBehaviour {

  
    public Rigidbody2D rigidBodyPurple2D;
    public bool isPurple;

    // Use this for initialization
    void Start ()
    {
       isPurple = false;
        this.transform.position = new Vector3(Random.Range(0.4f, 11.2f), Random.Range(7f, 11.5f), (0f));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPurple)
        {
            
            this.rigidBodyPurple2D.gravityScale = 1;
            this.rigidBodyPurple2D.velocity = new Vector2(5.2f, 5.2f);
            
            isPurple = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       // Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f))
        Vector2 tweak = new Vector2(0.2f, 0.3f);
        //this.GetComponent<Rigidbody2D>().velocity += tweak;
        this.rigidBodyPurple2D.velocity += tweak;
    }
}
