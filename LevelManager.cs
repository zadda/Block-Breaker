/*attached to a create empty gameobject called LevelManager
 * on load level and loadnextLevel resets counters
 * if breakable count reaches 0 or < loads next level or win
 */


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

  
   public void LoadLevel(string nameLevel)
    {
        Brick.breakableCount = 0;
        Brick.groenTeller = 0;
        SceneManager.LoadScene(nameLevel);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Brick.groenTeller = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
  
    //load next level if the required number of bricks is destroyed
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

}
