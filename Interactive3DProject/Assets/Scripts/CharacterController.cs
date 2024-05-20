using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Playables;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CharacterController : MonoBehaviour
{
    float translationSpeed = 2.0f;
        float rotationSpeed = 150f;
        private Animator animator;
    
        public int logsCollected;

        public GameObject Lane;
        
        public GameObject EnemyHitbox;
        
        [SerializeField] private Animator Dragon;

        [SerializeField] private int DragonHp = 10;

        private Rigidbody rb;

        private bool AttackcoolDown;

        [SerializeField] GameObject[] ListofBodyParts;
      
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
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

            if (GetComponent<BoxCollider>())
            {
               CheckEnemy();
                
                if (Input.GetKeyDown(KeyCode.Space) && AttackcoolDown == false && EnemyHitbox != null)
                {
                    StartCoroutine(PlayerAttack());
                }
                
                
            }
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

        private IEnumerator PlayerAttack()
        {
            if (EnemyHitbox.gameObject.name == "DragonHitBox")
            {
                AttackcoolDown = true;
                DragonHp--;
                animator.SetBool("PlayerAttack", true);
                if (DragonHp == 5)
                {
                    Dragon.SetBool("KnockBack", true);
                    
                }
                
                else
                {
                    Dragon.SetBool("GetHit", true);
                }
                Debug.Log("Hit Dragon");
                yield return new WaitForSeconds(0.25f);
                
                animator.SetBool("PlayerAttack", false);
                if (DragonHp == 5)
                {
                    Dragon.SetBool("KnockBack", false);
                }
                else
                {
                    Dragon.SetBool("GetHit", false);
                }

                if (DragonHp <= 0)
                {
                    Destroy(Dragon.GetComponent<GameObject>());
                }

                yield return new WaitForSeconds(1);
                AttackcoolDown = false;
            }
        }

        private void CheckEnemy()
        {
            Collider[] colliders = Physics.OverlapBox(GetComponent<BoxCollider>().bounds.center,GetComponent<BoxCollider>().bounds.extents, Quaternion.identity);
        
            var enemyColliders = colliders.Where(collider => collider.CompareTag("Enemy")).ToArray();

            foreach (Collider Enemy in colliders)
            {
                if (Enemy.gameObject.CompareTag("Enemy"))
                {
                    EnemyHitbox = Enemy.gameObject;
                }
            }
            
        }

       
        
        
        
}
