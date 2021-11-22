using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject player;
    [SerializeField] GameObject opponent;
    [SerializeField] float speed;
    float playerVelocity;
    #endregion

    #region Update
    void Update()
    {
        // Move the ball
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    #endregion

    #region OnCollisionEnter2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the ball collides with a character
        if (collision.gameObject == player)
        {
            // Add player velocity and a random value to the ball rotation
            playerVelocity = gameObject.GetComponent<GetVelocity>().velocity;
            Quaternion rotation = transform.rotation;
            rotation.x += Random.Range(0f, 20f);
            rotation.x += playerVelocity;
            rotation.x += 180f;
            transform.rotation = rotation;
        }

        // If the ball collides with the border
        if (collision.gameObject.tag == "out")
        {
            // Give point
        }
    }
    #endregion
}
