using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Panel : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }
    private void Pause()
    {
        _pausePanel.SetActive(true);
        _animator.SetBool("IsPause", true);
        Time.timeScale = 0.0f;
    }
    public void Resume_Button()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Menu_Button()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
