using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    int logsCollected;
    public GameObject bridge;
    
    // Start is called before the first frame update
    void Start()
    {
        logsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        logs();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "log")
        {
            Destroy(collision.gameObject);
            logsCollected += 1;
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("log"))
        {
            Destroy(other.gameObject);
            logsCollected += 1;
        }
    }
    */

    private void logs()
    {
        if (logsCollected == 4)
        {
            bridge.SetActive(true);
        }
    }
}
