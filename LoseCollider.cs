using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    
    private LevelManager levelManager;
    public string naamLevel; // te wijzigen??
    //private PurpeBall purpleBall;
    public static int maxHits;
    private string teLadenLevel;
    private int teller;

   void Start()
    {
        maxHits = 1;
        teller = 0;
    }

 void OnTriggerEnter2D(Collider2D objectWeHit)
    {
        //Debug.Log("Trigger");
        teller += 1;

        if (teller >= maxHits)
        {
           // Debug.Log(purpleBall);
            levelManager = GameObject.FindObjectOfType<LevelManager>();

            teLadenLevel = SceneManager.GetActiveScene().buildIndex + 1.ToString();

            //TODO load current/previous level, uitgezonderd laatste level?
            //levelManager.LoadLevel(teLadenLevel); // verschilt met code cursus
            levelManager.LoadLevel("Lose"); // verschilt met code cursus
            maxHits--;
        }
    }
    
void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Collision");
    }
}
