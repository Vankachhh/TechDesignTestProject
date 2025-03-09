using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject esc_panel;
    [SerializeField] private int isPaused = 0;

    [SerializeField] private Animator curtain_animator;
    [SerializeField] private Animator clouds_animator; // уникально для сцены adventure

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused != 3)
        {
            if (isPaused == 1)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        esc_panel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = 0;
    }

    public void Pause()
    {
        esc_panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = 1;
    }
    public void To_menu_button()
    {
        Resume();
        isPaused = 3; // чтобы нельзя было нажать паузу во время перехода в другую сцену
        StartCoroutine(To_menu());
    }
    public void To_quiz_button()
    {
        Resume();
        isPaused = 3; // чтобы нельзя было нажать паузу во время перехода в другую сцену
        StartCoroutine(To_quiz());
    }
    public void To_adventure_button()
    {
        Resume();
        isPaused = 3; // чтобы нельзя было нажать паузу во время перехода в другую сцену
        StartCoroutine(To_adventure());
    }


    IEnumerator To_menu()
    {
        clouds_animator.SetBool("close", true);
        curtain_animator.SetBool("close", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        StopAllCoroutines();
    }
    IEnumerator To_quiz()
    {
        clouds_animator.SetBool("close", true);
        curtain_animator.SetBool("close", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
        StopAllCoroutines();
    }
    IEnumerator To_adventure()
    {
        clouds_animator.SetBool("close", true);
        curtain_animator.SetBool("close", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
        StopAllCoroutines();
    }
}
