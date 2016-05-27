using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    
    private LevelManager levelManager;
    public string naamLevel; // te wijzigen??

 void OnTriggerEnter2D(Collider2D objectWeHit)
    {
        //Debug.Log("Trigger");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose"); // verschilt met code cursus
    }
    
void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Collision");
    }

}
