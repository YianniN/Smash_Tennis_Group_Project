using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] float speed;
    #endregion

    #region Update
    void Update()
    {
        // Movement
        Vector3 playerTransform = transform.position;
        playerTransform.x += Input.GetAxisRaw("Horizontal");
        playerTransform.y += Input.GetAxisRaw("Vertical");
        playerTransform.x = Mathf.Clamp(playerTransform.x, -1f, 5.5f);
        playerTransform.y = Mathf.Clamp(playerTransform.y, - 4.5f, 4.5f);
        transform.position = playerTransform;
    }
    #endregion
}
