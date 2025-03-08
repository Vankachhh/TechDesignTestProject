using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator; // аниматор игрока

        [SerializeField] private Animator campfire_animator;

        [SerializeField] private Animator teleport_animator;
        [SerializeField] private GameObject teleport_obj;

        [SerializeField] private GameObject teleport_button_img;

        [SerializeField] private Transform teleport_1;
        [SerializeField] private Transform teleport_2;

        [SerializeField] private int teleported_to = 0;
        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.name == "props_altar_1" && Input.GetKey(KeyCode.E))
            {
                    teleported_to = 2;
                    StartCoroutine(teleport());
            }
            if (collision.gameObject.name == "props_altar_2" && Input.GetKey(KeyCode.E))
            {
                    teleported_to = 1;
                    StartCoroutine(teleport());
            }


            if(collision.gameObject.name == "campfire" && Input.GetKey(KeyCode.E))
            {
                    campfire_animator.SetInteger("fire", 1);
            }
            if(collision.gameObject.name == "campfire" && Input.GetKey(KeyCode.E) && campfire_animator.GetInteger("fire") == 1)
            {
        //        campfire_animator.SetInteger("fire", 0);
            }
        }
        IEnumerator teleport()
        {
            speed = 0;
            teleport_obj.SetActive(true);
            teleport_animator.SetBool("is_teleported", true);
            teleport_button_img.SetActive(false);
            yield return new WaitForSeconds(2);
            if(teleported_to == 2)
            {
                gameObject.transform.position = teleport_2.position;
            }
            if (teleported_to == 1)
            {
                gameObject.transform.position = teleport_1.position;
            }
            yield return new WaitForSeconds(2);
            teleport_animator.SetBool("is_teleported", false);
            teleported_to = 0;
            speed = 3;
            StopCoroutine(teleport());
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "props_altar_1" || collision.gameObject.name == "props_altar_2")
            {
                teleport_button_img.SetActive(true);
            }
        }
        public void OnTriggerExit2D(Collider2D collision)
        {
            teleport_button_img.SetActive(false);
        }

    }
}
