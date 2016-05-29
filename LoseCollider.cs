/* this script is attached to the lose collider in play space
 * default game over after 1 hit
 * when purple ball is in play maxhit = 2
 * switches to game over screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour {
    
    public string naamLevel; // te wijzigen??
    public static int maxHits;

    private LevelManager levelManager;
    private int teller;

   void Start()
    {
        maxHits = 1;
        teller = 0;
    }

 void OnTriggerEnter2D(Collider2D objectWeHit)
    {
        teller += 1;

        if (teller >= maxHits)
        {
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Lose"); // verschilt met code cursus
            maxHits--;
        }
    }
}
