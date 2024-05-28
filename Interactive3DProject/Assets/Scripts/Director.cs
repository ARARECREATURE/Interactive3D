using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Director : MonoBehaviour
{
    private PlayableDirector director;
    public PlayableAsset[] timeline;
    private int currentTimeline = 0;

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        //runningScene();
        //runningScene2();
    }

    private void Start()
    {
        //nextTimeline();
    }

    private void Update()
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

    public void nextTimeline()
    {
        if (currentTimeline < timeline.Length)
        {
            director.playableAsset = timeline[currentTimeline];
            director.Play();
        }
    }
}
