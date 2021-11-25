using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for the ai gameplay
 */
public class AIController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Transform ball;
    [SerializeField]
    [Range(0f, 5f)]
    float xSpeed;
    [SerializeField]
    [Range(0f, 5f)]
    float ySpeed;
    [SerializeField]
    [Range(0f, 10f)]
    float maxDistance;
    public bool canMove;
    Vector2 ballDirection;
    Vector2 startPosition;
    #endregion

    #region Start
    void Start()
    {
        startPosition = transform.position;
    }
    #endregion

    #region Update
    void Update()
    {
        // Distance between ai and ball
        float distance = Vector2.Distance(transform.position, ball.transform.position);

        // Move
        if (distance < maxDistance && canMove)
        {
            // Y movement
            if (transform.position.y < ball.transform.position.y)
            {
                transform.position += transform.up * ySpeed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.up * ySpeed * Time.deltaTime;
            }

            // X movement
            if (transform.position.x < ball.transform.position.x)
            {
                transform.position += transform.right * xSpeed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.right * xSpeed * Time.deltaTime;
            }
        }
        else
        {
            // Distance between ai and start position
            distance = Vector2.Distance(transform.position, startPosition);

            // Y movement
            if (transform.position.y < startPosition.y && distance > ySpeed * Time.deltaTime)
            {
                transform.position += transform.up * ySpeed * Time.deltaTime;
            }
            else if (transform.position.y > startPosition.y && distance > ySpeed * Time.deltaTime)
            {
                transform.position -= transform.up * ySpeed * Time.deltaTime;
            }

            // X movement
            if (transform.position.x < startPosition.x && distance > xSpeed * Time.deltaTime)
            {
                transform.position += transform.right * xSpeed * Time.deltaTime;
            }
            else if (transform.position.x > startPosition.x && distance > xSpeed * Time.deltaTime)
            {
                transform.position -= transform.right * xSpeed * Time.deltaTime;
            }
        }

        // Clamp
        Vector3 aiTransform = transform.position;
        aiTransform.x = Mathf.Clamp(aiTransform.x, -6.85f, -1.65f);
        aiTransform.y = Mathf.Clamp(aiTransform.y, -3.1f, 3.1f);
        transform.position = aiTransform;
    }
    #endregion

    #region Reset
    public void Reset()
    {
        canMove = true;
        transform.position = startPosition;
    }
    #endregion
}
