using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject esc_panel;
    [SerializeField] private bool isPaused;

    [SerializeField] private Animator curtain_animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        isPaused = false;
    }

    public void Pause()
    {
        esc_panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void To_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void To_quiz()
    {
        SceneManager.LoadScene(1);
    }
    public void To_adventure()
    {
        SceneManager.LoadScene(2);
    }
}
