using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quiz : MonoBehaviour
{
    [SerializeField] private Animator lever_animator;
    [SerializeField] private Animator wheel_animator;
    [SerializeField] private int is_pressed = 0;

    [SerializeField] private TMP_Text dialogue_text;
    [SerializeField] private float typing_speed = 0.01f; // �������� ��������� ������ � ���������� ����
    [SerializeField] private string full_text;

    [SerializeField] private GameObject confetti;

    void Update()
    {   
        if (Input.GetKey(KeyCode.S))
        {
            wheel_spin_button();
        }
    }
    public void wheel_spin_button()
    {
        if (is_pressed == 0)  // �.�. �������� �� ������� ����� � Update, ������ �������, �� �������� ��� �������� ����� ����������� ���� ����� ������������ ���� ��������
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
        yield return new WaitForSeconds(3);
        lever_animator.SetBool("is_down", false);
        yield return new WaitForSeconds (1.5f);
        confetti.SetActive(true);
        yield return new WaitForSeconds(2f); // ����� ��� �������� �� ����
        is_pressed = 0;
        StopCoroutine(lever_up());
    }
    IEnumerator typing_text_after_spin()
    {
        yield return new WaitForSeconds(3);

        dialogue_text.text = "";
        full_text = "����� �������������! ������ ������ �� ������!";
        for (int i = 0; i < full_text.Length; i++) 
        { 
            dialogue_text.text += full_text[i];
            dialogue_text.fontSize = 40;
            yield return new WaitForSeconds(typing_speed); 
        }
        yield return new WaitForSeconds(1);

        dialogue_text.text = "";
        full_text = "�������� �������!";
        for (int i = 0; i < full_text.Length; i++)
        {
            dialogue_text.text += full_text[i];
            dialogue_text.fontSize = 60;
            yield return new WaitForSeconds(typing_speed);
        }
        yield return new WaitForSeconds(2f);
        confetti.SetActive(false);
        StopCoroutine(typing_text_after_spin());
    }
}
