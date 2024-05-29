using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRuby.PyroParticles;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lanes : MonoBehaviour
{
    [SerializeField] private GameObject[] DifferentLanes;
    [SerializeField] private Material Black;
    [SerializeField] private Material Red;

    [SerializeField] private Animator Dragon;
    [SerializeField] CharacterController PlayerCharacter; 

    private float Timer = 0.0f;

    public float TimeforAttack;

    [SerializeField] private GameObject Lane1flame;
    
    [SerializeField] private GameObject Lane2flame;
    
    [SerializeField] private GameObject Lane3flame;

    [SerializeField] private AudioSource DragonAttackSound;
    
    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= TimeforAttack)
        {
            
            Timer = 0.0f;
            StartCoroutine(AttackCorontine());
        }
    }
    private IEnumerator AttackCorontine()
    {
        Dragon.SetBool("FlameAttack", true);
        int RandomNumber = Random.Range(0, DifferentLanes.Length);
        GameObject RandomLane = DifferentLanes[RandomNumber];
        Renderer LaneRenderer =  DifferentLanes[RandomNumber].GetComponent<Renderer>(); 
        LaneRenderer.material = Red;

        if (RandomLane.name == "Lane1")
        {
            Lane1flame.SetActive(true);
        }
        if (RandomLane.name == "Lane2")
        {
            Lane2flame.SetActive(true);
        }
        if (RandomLane.name == "Lane3")
        {
            Lane3flame.SetActive(true);
        }

        
        
        yield return new WaitForSeconds(3.0f);
        DragonAttackSound.Play(1);
        Dragon.SetBool("FlameAttack", false);
        if (PlayerCharacter.Lane == RandomLane)
        {
            Debug.Log("Hit Player");
            
        }
        else
        {
            Debug.Log("missed");
        }
        
        
        
        LaneRenderer.material = Black;
        Lane1flame.SetActive(false);
        Lane2flame.SetActive(false);
        Lane3flame.SetActive(false);
    }
}

