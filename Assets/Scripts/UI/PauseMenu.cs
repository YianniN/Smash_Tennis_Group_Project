using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject pauseMenu;
    bool paused;
    #endregion

    #region OnGUI
    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }
    #endregion

    #region Pause
    public void Pause()
    {
        // Show pause menu
        pauseMenu.SetActive(true);
    }
    #endregion

    #region UnPause
    public void UnPause()
    {
        // Hide pause menu
        pauseMenu.SetActive(false);
    }
    #endregion
}
