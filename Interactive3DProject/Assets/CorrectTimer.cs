using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRuby.PyroParticles;
using Unity.VisualScripting;
using UnityEngine;

public class CorrectTimer : MonoBehaviour
{
    private FireConstantBaseScript thisFire;

    
    [SerializeField] private float timer;

    private float counter;
    private void Start()
    {
        thisFire = this.gameObject.GetComponent<FireConstantBaseScript>();
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= timer)
        {
            thisFire.enabled = true;
        }
    }
}
