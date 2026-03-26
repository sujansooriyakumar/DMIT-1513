using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public InputAction pauseInput;
    public GameObject pauseMenuUI;
    public static PauseMenuController instance;
    private bool isPaused = false;
    public event Action<bool> OnPauseToggle;
    private void Start()
    {
        instance = this;
        pauseInput.Enable();
        pauseInput.performed += PauseInputPressed;
    }

    private void PauseInputPressed(InputAction.CallbackContext c)
    {
        if (!isPaused)
        {
            Pause();
            return;
        }

        Resume();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        OnPauseToggle?.Invoke(isPaused);
        
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;

        pauseMenuUI.SetActive(false);
        isPaused = false;
        OnPauseToggle?.Invoke(isPaused);

    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
