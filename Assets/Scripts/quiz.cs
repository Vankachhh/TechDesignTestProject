using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quiz : MonoBehaviour
{
    [SerializeField] private Animator lever_animator;
    [SerializeField] private Animator wheel_animator;
    [SerializeField] private int is_pressed = 0;

    [SerializeField] private TMP_Text spin_text;
    [SerializeField] private TMP_Text win_text;
    [SerializeField] private float typing_speed = 0.01f; // скорость печатания текста в диалоговом окне
    [SerializeField] private string full_text;

    [SerializeField] private GameObject confetti;


    [SerializeField] private AudioSource win_sound;
    [SerializeField] private AudioSource wheel_spin_sound;
    void Update()
    {   
        if (Input.GetKey(KeyCode.S))
        {
            wheel_spin_button();
        }
    }
    public void wheel_spin_button()
    {
        if (is_pressed == 0)  // т.к. проверка на нажатие лежит в Update, создаю условие, по которому это действие будет выполняться лишь после проигрывания всей анимации
        {
            lever_animator.SetBool("is_down", true);
            wheel_animator.SetBool("spin", !wheel_animator.GetBool("spin"));
            is_pressed = 1;
            StartCoroutine(lever_up());
            StartCoroutine(typing_text_after_spin());
        }
    }
    IEnumerator lever_up()
    {
        wheel_spin_sound.Play();
        yield return new WaitForSeconds(3);
        lever_animator.SetBool("is_down", false);
        yield return new WaitForSeconds (1.5f);
        win_sound.Play();
        confetti.SetActive(true);
        yield return new WaitForSeconds(4f); // время для ведущего на речь
        is_pressed = 0;
        StopCoroutine(lever_up());
    }
    IEnumerator typing_text_after_spin()
    {
        yield return new WaitForSeconds(3);
        win_text.gameObject.SetActive(true);
        spin_text.gameObject.SetActive(false);

        yield return new WaitForSeconds(6f);
        win_text.gameObject.SetActive(false);
        spin_text.gameObject.SetActive(true);
        confetti.SetActive(false);
        StopCoroutine(typing_text_after_spin());
    }
}
