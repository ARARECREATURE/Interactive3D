using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CharacterController : MonoBehaviour
{
    float translationSpeed = 2.0f;
        float rotationSpeed = 150f;
        private Animator animator;
    
        public int logsCollected;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            float translation = Input.GetAxis("Vertical") * translationSpeed;
            translation *= Time.deltaTime;
            transform.Translate(0, 0, translation);

            float rotation= Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                animator.SetBool("isWalk", true);



            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("isWalk", false);
            }

            animator.SetBool("isRun", Input.GetKey(KeyCode.LeftShift));

            




        
        }

        public virtual void collectlog()
        {
            logsCollected++;
        }
}
