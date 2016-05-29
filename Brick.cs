/*script attached to the grey, light red, regular red and brown brick
 * at start counts the number of bricks to destroy
 * when brick is hit checks if it's a regular hit
 * or a hit with a green ball
 * when hit by a green ball hits +2
 * a static int, only one instance, reset in levelmanager on loadlevel 
 * and loadnextlevel
 */


using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


    public Sprite[] hitSprites; //array
    public static int breakableCount = 0;
    public GameObject smoke;
    public Color Colour;

    public static int groenTeller = 0;
    //public AudioClip crack;
    


    private int timesHit;
    private LevelManager levelManager;
    private Special special;
    private Ball brickBall;
    
    
    private bool isBreakable;
    
    

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");        
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        special = GameObject.FindObjectOfType<Special>();
        brickBall = GameObject.FindObjectOfType<Ball>();
        timesHit = 0;
        

        // bij de start worden alle te destroyen objecten overlopen en opgeteld
        if (isBreakable)
        {
            breakableCount++;
        }
       
    }


    void OnCollisionEnter2D(Collision2D col)
    {
       
        //AudioSource.PlayClipAtPoint(crack, transform.position);

        if (special.isGreen && isBreakable)
        {
            
            if (groenTeller < 3)
            {
                HandleHitsSpecial();
            }
            else if (groenTeller >= 3)
            {
                special.isGreen = false;
                brickBall.GetComponent<SpriteRenderer>().sprite = brickBall.ballSprites[2]; // 0 = groen, 1 = rood, 2 = grijs
                HandleHits();
            }
           
        }
        else if (!special.isGreen && isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;

        //int maxHits; // public om te kunnen aanpassen in editor

        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits) // groter of gelijk anders probleem als we met een speciale bal spelen
        {
            breakableCount--;
            
           
            GameObject smokePuff = Instantiate(smoke, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            // kleur wordt in de inspector gezet via Colour -> Alpha op 255  zetten!!
            smokePuff.GetComponent<ParticleSystem>().startColor = new Vector4 (this.GetComponent<Brick>().Colour.r, this.GetComponent<Brick>().Colour.g, this.GetComponent<Brick>().Colour.b, this.GetComponent<Brick>().Colour.a);
           
            
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    public void HandleHitsSpecial()
    {

        groenTeller++;
        timesHit +=2;
        //int maxHits; // public om te kunnen aanpassen in editor

        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits) // groter of gelijk anders probleem als we met een speciale bal spelen
        {
            breakableCount--;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }


    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;

        // in case we don't have a 2nd and 3d sprite set
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; // change the brick so that it shows that it's been hit
        }
        else
        {
            Debug.LogError("Brick sprite missing",gameObject);
        }
    }
}
