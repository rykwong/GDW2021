using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*If we have audio, we will also have to turn that off in this code. 
 * 
 * Currently, I do not have audio so sound will not be turned off.
 * 
 * Attach this to the PauseScreen canvas. 
 */
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //this covers pressing a key down twice
            //if the game is paused, the next time I press Esc, it will resume. 

            PauseGame();
        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {

            Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
    }
    public void Menu()
    {
        Debug.Log("Loading Menu....");
    }
    public void Options()
    {
        Debug.Log("Loading Options....");
    }
    public void QuitGame()
    {
        Debug.Log("QUitting game");
        Application.Quit();
    }
}
