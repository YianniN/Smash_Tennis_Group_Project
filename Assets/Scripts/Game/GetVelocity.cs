using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script gets the player velocity
 */
public class GetVelocity : MonoBehaviour
{
    #region Variables
    [Header("Dont touch this")]
    public float velocity;
    float oldPos;
    float newPos;
    #endregion

    #region Start
    void Start()
    {
        oldPos = transform.position.y;
    }
    #endregion

    #region Update
    void Update()
    {
        // Get velocity of player
        newPos = transform.position.y;
        velocity = (oldPos - newPos) * 200;
        oldPos = newPos;
    }
    #endregion
}
