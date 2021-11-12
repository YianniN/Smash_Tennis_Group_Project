using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is for selecting the training and choosing a timer
 */
public class LevelSelection : MonoBehaviour
{
    #region Variables
    [Header("References")]
    // We keep an array of the levels so we can enable or disable the buttons depending on what levels are unlocked
    [SerializeField] private GameObject[] levels;
    // This variable stores what level were up to
    [Header("Dont change these")]
    static public int currentLevel;
    public string trainingSelection;
    #endregion

    #region Start
    private void Start()
    {
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.GetInt("currentLevel", 0);
        // Disables all the buttons for levels
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        // Enables the buttons for levels that are unlocked
        for (int i = 0; i < currentLevel; i++)
        {
            levels[i].SetActive(true);
        }
    }
    #endregion

    // This is the function we call from the button for each level in the level selection screen. Make sure the name of the button GameObject is same as the scene name
    #region SelectLevel
    public void SelectLevel(GameObject selection)
    {
        // Store the button name in a string to use later when loading the scene
        trainingSelection = selection.name;

        LoadLevel();
    }
    #endregion

    #region LoadLevel
    private void LoadLevel()
    {
        // Loads the training scene
        SceneManager.LoadScene(trainingSelection);
    }
    #endregion
}
