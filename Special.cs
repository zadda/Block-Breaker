/* Special.cs is attached to the green brick
 * it randomly sets the x axis position of ^
 * when hit the green brick is destroyed
 * the normal balls sprite is changed to a green one
 * isGreen is set to true this is used in Brick.cs
*/

using UnityEngine;
using System.Collections;
using System.Timers;

public class Special : MonoBehaviour {

    public bool isGreen;

    private LevelManager levelManager;
    private Brick brick;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        //random locatie voor groene brick
        this.transform.position = new Vector3(Random.Range(1f,15.5f), 8.96f, 0f); //y as4.8f
    }

    void OnCollisionEnter2D(Collision2D col)
    {
          ball.GetComponent<SpriteRenderer>().sprite = ball.ballSprites[0]; // 0 = groen, 1 = rood, 2 = grijs
          isGreen = true;
          Destroy(gameObject);
    }
}