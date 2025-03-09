using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class adventure : MonoBehaviour
{
    [SerializeField] private Animator campfire_animator;

    [SerializeField] private Animator teleport_animator;
    [SerializeField] private GameObject teleport_obj;

    [SerializeField] private GameObject teleport_button_img;

    [SerializeField] private Transform teleport_1;
    [SerializeField] private Transform teleport_2;

    [SerializeField] private int teleported_to = 0;

    [SerializeField] private GameObject Player;
    [SerializeField] private TopDownCharacterController script;

    [SerializeField] private GameObject buttons;

    [SerializeField] private AudioSource fire_start;
    [SerializeField] private AudioSource fire_finish;
    public void Start()
    {
         script = Player.GetComponent<TopDownCharacterController>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        buttons.SetActive(true);
        buttons.transform.position = new Vector3 (Player.transform.position.x + 0.3f, Player.transform.position.y + 0.9f, Player.transform.position.z);

        if (collision.gameObject.name == "props_altar_1" && Input.GetKey(KeyCode.E))
        {
            teleported_to = 2;
            StartCoroutine(teleport());
        }
        if (collision.gameObject.name == "props_altar_2" && Input.GetKey(KeyCode.E))
        {
            teleported_to = 1;
            StartCoroutine(teleport());
        }

        if (collision.gameObject.name == "campfire" && Input.GetKey(KeyCode.E))
        {
            campfire_animator.SetInteger("fire", 1);
            buttons.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            fire_start.Play();
        }
        if (collision.gameObject.name == "campfire" && Input.GetKey(KeyCode.Q))
        {
            campfire_animator.SetInteger("fire", 2);
            buttons.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            fire_finish.Play();
        }
    }

    IEnumerator teleport()
    {
        script.speed = 0;
        teleport_obj.SetActive(true);
        teleport_animator.SetBool("is_teleported", true);
        teleport_button_img.SetActive(false);
        yield return new WaitForSeconds(2);
        if (teleported_to == 2)
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
        script.speed = 3;
        StopCoroutine(teleport());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "props_altar_1" || collision.gameObject.name == "props_altar_2")
        {
            teleport_button_img.SetActive(true);
        }
        if(collision.gameObject.name == "campfire" && campfire_animator.GetInteger("fire") == 2)
        {
             buttons.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(collision.gameObject.name == "campfire" && campfire_animator.GetInteger("fire") == 1)
        {
            buttons.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        teleport_button_img.SetActive(false);
        buttons.SetActive(false);
        buttons.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
