using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    
    private LevelManager levelManager;
    public string naamLevel; // te wijzigen??
    //private PurpeBall purpleBall;
    public static int maxHits;
    private int teller;

   void Start()
    {
        maxHits = 1;
        teller = 0;
        
        //isGameOver = (this.tag == "PaarsBal");
        //purpleBall = GameObject.FindObjectOfType<PurpeBall>();
    }

 void OnTriggerEnter2D(Collider2D objectWeHit)
    {
        //Debug.Log("Trigger");
        teller += 1;

        if (teller >= maxHits)
        {
           // Debug.Log(purpleBall);
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Lose"); // verschilt met code cursus
            maxHits--;
        }

        
    }
    
void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Collision");
    }

}
