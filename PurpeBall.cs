using UnityEngine;
using System.Collections;

public class PurpeBall : MonoBehaviour {

  
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
            this.rigidBodyPurple2D.velocity = new Vector2(-5.2f, -5.2f);
            isPurple = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       // Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f))
        Vector2 tweak = new Vector2(0.2f, 0.3f);
        this.GetComponent<Rigidbody2D>().velocity += tweak;
    }
}
