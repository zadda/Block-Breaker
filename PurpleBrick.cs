using UnityEngine;
using System.Collections;

public class PurpleBrick : MonoBehaviour {

    private PurpeBall ball;

	// Use this for initialization
	void Start ()
    {
       
        ball = GameObject.FindObjectOfType<PurpeBall>();
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        ball.isPurple = true;
        Destroy(gameObject);
        LoseCollider.maxHits += 1;
    }
}
