using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This script is for the dialogue of the ai and player
 */
public class Dialogue : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject storyboard;
    [SerializeField]
    Text dialogueText;
    public string[] preGameDialogue;
    public string[] winDialogue;
    public string[] loseDialogue;
    public bool preGame, win, lose, textSet;
    #endregion

    #region Start
    void Start()
    {
        preGame = true;
    }
    #endregion

    #region Update
    void Update()
    {
        PreGame();
        Win();
        Lose();
    }
    #endregion

    #region PreGame
    void PreGame()
    {
        if (preGame)
        {
            Time.timeScale = 0;

            // Show the storyboard
            storyboard.SetActive(true);

            // Set the dialogue text
            if (!textSet)
            {
                dialogueText.text = preGameDialogue[Random.Range(0, preGameDialogue.Length)];
                textSet = true;
            }

            // Go to next dialogue
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                storyboard.SetActive(false);
                preGame = false;
                gameManager.Wait();
            }
        }
    }
    #endregion

    #region Win
    void Win()
    {
        if (win)
        {
            Time.timeScale = 0;

            // Show the storyboard
            storyboard.SetActive(true);

            // Set the dialogue text
            if (!textSet)
            {
                dialogueText.text = winDialogue[Random.Range(0, winDialogue.Length)];
                textSet = true;
            }

            // Go to next dialogue
            if (Input.GetMouseButtonDown(0))
            {
                    SceneManager.LoadScene("MainMenu");
            }
        }
    }
    #endregion

    #region Win
    void Lose()
    {
        if (lose)
        {
            Time.timeScale = 0;

            // Show the storyboard
            storyboard.SetActive(true);

            // Set the dialogue text
            if (!textSet)
            {
                dialogueText.text = loseDialogue[Random.Range(0, loseDialogue.Length)];
                textSet = true;
            }

            // Go to next dialogue
            if (Input.GetMouseButtonDown(0))
            {
                    SceneManager.LoadScene("MainMenu");
            }
        }
    }
    #endregion
}
