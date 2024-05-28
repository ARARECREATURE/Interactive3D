using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;
    
    [SerializeField]
    private GameObject orb;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        orb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isOpen", true);
            //orb.SetActive(true);
            StartCoroutine(spawnOrb());
        }
    }

    IEnumerator spawnOrb()
    {
        yield return new WaitForSeconds(1.1f);
        orb.SetActive(true);
    }
}
