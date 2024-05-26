#if UNITY_EDITOR
using Unity.VisualScripting;
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PauseMenu pauseMenu;
    private InputAction pauseActionP;
    private InputAction pauseActionEscape;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the pause actions with different keyboard bindings
        pauseActionP = new InputAction(binding: "<Keyboard>/p");
        pauseActionEscape = new InputAction(binding: "<Keyboard>/escape");

        // Add listeners for both actions
        pauseActionP.started += ctx => TogglePause();
        pauseActionEscape.started += ctx => TogglePause();
    }

    void OnEnable()
    {
        // Enable both pause actions
        pauseActionP.Enable();
        pauseActionEscape.Enable();
    }

    void OnDisable()
    {
        if (pauseActionP != null)
            pauseActionP.Disable();

        if (pauseActionEscape != null)
            pauseActionEscape.Disable();
    }

    private void TogglePause()
    {
        Debug.Log("Pause key pressed");
        if (!pauseMenu.PausePanel.activeSelf)
        {
            // Pause the game
            pauseMenu.Pause();
        }
        else
        {
            // Continue the game
            pauseMenu.Continue();
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
