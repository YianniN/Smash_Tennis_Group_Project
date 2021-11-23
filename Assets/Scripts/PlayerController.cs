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
        playerTransform.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        playerTransform.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        playerTransform.x = Mathf.Clamp(playerTransform.x, -1.1f, 4.15f);
        playerTransform.y = Mathf.Clamp(playerTransform.y, -3.1f, 3.1f);
        transform.position = playerTransform;
    }
    #endregion
}
