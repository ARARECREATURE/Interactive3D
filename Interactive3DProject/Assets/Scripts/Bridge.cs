using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject bridge;
    public CharacterController player;

    private void Update()
    {
        if (player.logsCollected == 4)
        {
            bridge.SetActive(true);
        }
    }
}
