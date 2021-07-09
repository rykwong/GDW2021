using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Attach this script to a canvas 
 * 
 */
public class StartMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("Game is being played!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUITTING!");
        Application.Quit();
    }
    public void Credits()
    {
        Debug.Log("Thank you for playing this game. Bye!");
    }
}
