using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float translationSpeed = 2.0f;
        float rotationSpeed = 150f;
        private Animator animator;
    
        public int logsCollected;

        public GameObject Lane;
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


            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 0.5f, LayerMask.GetMask("Floor")))
            {
                Lane = hit.collider.gameObject;
            }
        }

        public virtual void collectlog()
        {
            logsCollected++;
        }
        
        
        
}
