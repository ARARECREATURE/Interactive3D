using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour
{
    [SerializeField] private float SwapTime;

    [SerializeField] private Camera CamSwap;
    [SerializeField] private Camera DisabledCam;

    [SerializeField] private GameObject Lanes;

    private float Counter;

    private void Update()
    {
        Counter += Time.deltaTime;
        if (Counter >= SwapTime)
        {
            CamSwap.enabled = true;
            DisabledCam.enabled = false;
            Lanes.GetComponent<Lanes>().enabled = true;
            this.enabled = false;
        }
    }
}
