using UnityEngine;
using System.Collections;

public class PurpleBrick : MonoBehaviour {

    private PurpeBall ball;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = new Vector3(Random.Range(1f, 15.5f), 9.28f, 0f);
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
