using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This is the game manager script
 */
public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    [Range(1, 4)]
    int level;
    [SerializeField]
    PauseMenu pauseMenu;
    [SerializeField]
    BallController ball;
    [SerializeField]
    PlayerController player;
    [SerializeField]
    AIController ai;
    [SerializeField]
    GameObject pressAnyKey;
    [SerializeField]
    Text aiPointsText;
    [SerializeField]
    Text playerPointsText;
    [SerializeField]
    Dialogue dialogue;
    bool wait, gameFinished;
    public int aiPoints;
    public int playerPoints;
    #endregion

    #region Update
    void Update()
    {
        if (wait)
        {
            if (Input.anyKeyDown && PauseMenu.paused == false)
            {
                wait = false;

                // Hide the press any key ui
                pressAnyKey.SetActive(false);
                ball.Reset();
                player.Reset();
                ai.Reset();
            }
        }

        // Update points text
        aiPointsText.text = aiPoints.ToString();
        playerPointsText.text = playerPoints.ToString();

        // Show win dialogue
        if (!gameFinished)
        {
            if (playerPoints == 5)
            {
                Win();
                gameFinished = true;
            }
            else if (aiPoints == 5)
            {
                Lose();
                gameFinished = true;
            }
        }
    }
    #endregion

    #region Wait
    public void Wait()
    {
        // Show the press any key ui
        pressAnyKey.SetActive(true);

        wait = true;
    }
    #endregion

    #region Win
    public void Win()
    {
        // Save progress
        if (LevelSelection.progress < level)
        {
            LevelSelection.progress = level;
        }
        LevelSelection.SaveProgress();

        // Show win dialogue
        dialogue.win = true;
        dialogue.textSet = false;
    }
    #endregion

    #region Lose
    public void Lose()
    {
        // Show lose dialogue
        dialogue.lose = true;
        dialogue.textSet = false;
    }
    #endregion

    #region MainMenu
    void MainMenu()
    {
        // Load main menu
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
