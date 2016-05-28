using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


    public Sprite[] hitSprites; //array
    public static int breakableCount = 0;
    public static int groenTeller = 0;
    //public AudioClip crack;
    public GameObject smoke;
    public Color Colour;    

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

       // groenTeller = 0;
        timesHit = 0;
        //special.isGreen = false;
        

        // bij de start worden alle objecten overlopen en opgeteld
        if (isBreakable)
        {
            breakableCount++;
            //Debug.Log("breakable count " + breakableCount);
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
            Debug.Log(Colour);
            
            Destroy(gameObject);
            levelManager.BrickDestroyed();
            //smoke.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
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

    // TODO remove this method once we acutally win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;


        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing",gameObject);
        }
    }
}
