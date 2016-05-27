using UnityEngine;
using System.Collections;

public class SpecialPaddle : MonoBehaviour
{

    
    private Paddle normalPaddle;
    private bool isPaddle;
    private bool isRed = false;
    private SpecialPaddle specialePaddle;
   

    // Use this for initialization
    void Start()
    {
        isPaddle = (this.tag == "Paddle");        
        isRed = (this.tag == "Rood");
        normalPaddle = GameObject.FindObjectOfType<Paddle>();
        specialePaddle = GameObject.FindObjectOfType<SpecialPaddle>();
        
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (isRed)
        {
            Destroy(gameObject);
            //Destroy(normalPaddle);
            
            Vector3 paddlePos = new Vector3(0f, 500f, 0f);

            normalPaddle.transform.position = paddlePos;
            isRed = false;

            //Destroy(normalPaddle);

           

            
            //normalPaddle.transform.position = paddlePos;
            

            //GameObject destroyedPaddlet = (GameObject)Instantiate(specialePaddle, normalPaddle.transform.position, normalPaddle.transform.rotation);
           // GameObject destroyedPaddlet = (GameObject)Instantiate(normalPaddle, specialePaddle.transform.position, specialePaddle.transform.rotation);
            //Destroy(normalPaddle);
            //Destroy(explosionGameObject);

            //normalPaddle.transform.TransformVector(0,5,3);

        }
    }

    void Update()
    {
        if (!isRed)
        {
            MoveMouse();
        }
        
    }

    void MoveMouse()
    {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        //verander positie van de paddle

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        // this is de paddle script de component zelf
        this.transform.position = paddlePos;

    }

}
