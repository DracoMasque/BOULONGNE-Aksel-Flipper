using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    bool paused = false;
    public GameObject menu;
    
    public void Pause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (!paused)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void ReLoad()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    
}
