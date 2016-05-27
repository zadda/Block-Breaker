using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake()
    {
        //Debug.Log("Music player Awake " + GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
            //print("duplicate music player destructed");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


	
	
}
