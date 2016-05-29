/*script attached to the purple brick
 * behaviour similar as Special.cs * 
 */


using UnityEngine;
using System.Collections;

public class PurpleBrick : MonoBehaviour {

    private PurpleBall ball;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = new Vector3(Random.Range(1f, 15.5f), 9.28f, 0f); // random position of purple brick (x-axis)
        ball = GameObject.FindObjectOfType<PurpleBall>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ball.isPurple = true;
        Destroy(gameObject);
        LoseCollider.maxHits += 1; // change the number of maxHits since we have an extra ball in play
    }
}
