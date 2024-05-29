using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SwapCamera : MonoBehaviour
{
    [SerializeField] private float SwapTime;

    [SerializeField] private Camera CamSwap;
    [SerializeField] private Camera DisabledCam;

    [SerializeField] private GameObject Lanes;

    private float Counter;

    [SerializeField] private GameObject[] DisableGameObjects;

    [SerializeField] private GameObject ExtraDirector;
    private void Update()
    {
        Counter += Time.deltaTime;
        if (Counter >= SwapTime)
        {
            CamSwap.enabled = true;
            DisabledCam.enabled = false;
            if (Lanes)
            {
                Lanes.GetComponent<Lanes>().enabled = true;
            }
            if (DisabledCam)
            {
                foreach (GameObject Disable in DisableGameObjects)
                {
                    Disable.SetActive(false);
                }
            }
                
            
            if (ExtraDirector)
            {
                ExtraDirector.GetComponent<PlayableDirector>().Play();
                this.enabled = false;
            }
            


        }
    }

    private void OnDisable()
    {
        if(CamSwap) CamSwap.enabled = false;
        if(DisabledCam) DisabledCam.enabled = true;
        if(Lanes) Lanes.GetComponent<Lanes>().enabled = false;
        
    }
}
