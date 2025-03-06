using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quiz : MonoBehaviour
{
    [SerializeField] private Animator lever_animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            lever_animator.SetBool("is_down", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            lever_animator.SetBool("is_down", false);
        }
    }
}
