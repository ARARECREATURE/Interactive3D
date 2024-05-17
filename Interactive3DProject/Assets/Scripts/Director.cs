using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Director : MonoBehaviour
{
    private PlayableDirector director;
    public PlayableAsset[] timeline;

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        //runningScene();
        //runningScene2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runningScene()
    {
        director.playableAsset = timeline[0];
        director.Play();
    }

    public void runningScene2()
    {
        director.playableAsset = timeline[1];
        director.Play();
    }
}
