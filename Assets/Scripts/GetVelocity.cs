using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        newPos = transform.position.y;
        velocity = (oldPos - newPos) * Time.deltaTime;
        oldPos = newPos;
    }
    #endregion
}
