using System;
using System.Collections;
using System.Collections.Generic;
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
        
        yield return new WaitForSeconds(3.0f);
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
        
    }
}

