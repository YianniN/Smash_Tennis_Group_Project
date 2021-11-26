using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject pauseMenu;
    public static bool paused;
    #endregion

    #region Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;

            if (paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }
    #endregion

    #region Pause
    public void Pause()
    {
        // Show pause menu
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
    }
    #endregion

    #region UnPause
    public void UnPause()
    {
        // Hide pause menu
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;
    }
    #endregion

    #region MainMenu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        paused = false;
    }
    #endregion
}
