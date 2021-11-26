using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script controls the ball
 */
public class BallController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    AIController ai;
    [SerializeField]
    PlayerController player;
    [SerializeField]
    float startSpeed;
    [SerializeField]
    [Range(0f, 0.5f)]
    float speedIncrement;
    float speed;
    [SerializeField]
    float maxRandomRotationValue;
    [SerializeField]
    GameObject gameManager;
    float playerVelocity;
    float rotationValue;
    float addRotation;
    #endregion

    #region Start
    void Start()
    {
        Reset();
    }
    #endregion

    #region Update
    void Update()
    {
        // Move the ball
        transform.position += transform.right * speed * Time.deltaTime;
    }
    #endregion

    #region Reset
    public void Reset()
    {
        // Reset position
        transform.position = new Vector3(-1.4f, 0, 0);
        // Set random rotation between 180 or -180
        transform.rotation = Quaternion.Euler(0, 0, 180 * Random.Range(0, 2));
        // Reset speed
        speed = startSpeed;
    }
    #endregion

    #region OnCollisionEnter2D
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the ball collides with a character
        if (collision.gameObject.tag == "Player")
        {
            // Set ai canMove to true
            ai.canMove = true;

            // Rotate by 180 + random value
            rotationValue = transform.rotation.eulerAngles.z;
            rotationValue += Random.Range(-20, 20);
            rotationValue += 180;
            transform.rotation = Quaternion.Euler(0, 0, rotationValue);

            // Player animation
            rotationValue = transform.rotation.z;

            if (rotationValue >= 0f)
            {
                player.Forehand();
            }
            else
            {
                player.Backhand();
            }
        }
        else if (collision.gameObject.tag == "AI")
        {
            // Set ai canMove to false
            ai.canMove = false;

            // Rotate by 180 + random value
            rotationValue = transform.rotation.eulerAngles.z;
            rotationValue += Random.Range(-maxRandomRotationValue, maxRandomRotationValue);
            rotationValue += 180;
            transform.rotation = Quaternion.Euler(0, 0, rotationValue);

            // AI animation
            rotationValue = transform.rotation.z;

            if (rotationValue >= 0f)
            {
                ai.Backhand();
            }
            else
            {
                ai.Forehand();
            }
        }
        speed += speedIncrement;

        // If the ball collides with a border
        if (collision.gameObject.tag == "AIBorder")
        {
            // Give point to player
            Debug.Log("Player Scored");
            gameManager.GetComponent<GameManager>().playerPoints += 1;

            gameManager.GetComponent<GameManager>().Wait();
            speed = 0;
        }
        else if (collision.gameObject.tag == "PlayerBorder")
        {
            // Give point to AI
            Debug.Log("AI Scored");
            gameManager.GetComponent<GameManager>().aiPoints += 1;

            gameManager.GetComponent<GameManager>().Wait();
            speed = 0;
        }
    }
    #endregion
}
