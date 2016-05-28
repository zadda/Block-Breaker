using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

  
   public void LoadLevel(string nameLevel)
    {
        //Debug.Log("Level load requested for: " + nameLevel);        
        Brick.breakableCount = 0;
        Brick.groenTeller = 0;
        SceneManager.LoadScene(nameLevel);
        
    }

    public void QuitGame()
    {
       // Debug.Log("Quit game requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        //  Application.LoadLevel(Application.loadedLevel +1));
        Brick.breakableCount = 0;
        Brick.groenTeller = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
  
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

}
