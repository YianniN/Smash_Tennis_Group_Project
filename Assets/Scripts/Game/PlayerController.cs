using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script controls the player
 */
public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    float speed;
    Animator animator;
    Vector2 startPosition;
    #endregion

    #region Start
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        startPosition = transform.position;
    }
    #endregion

    #region Update
    void Update()
    {
        // Input
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Move
        transform.position += input.normalized * speed * Time.deltaTime;

        // Clamp
        Vector3 playerTransform = transform.position;
        playerTransform.x = Mathf.Clamp(playerTransform.x, -1.1f, 4.15f);
        playerTransform.y = Mathf.Clamp(playerTransform.y, -3.1f, 3.1f);
        transform.position = playerTransform;
    }
    #endregion

    #region Reset
    public void Reset()
    {
        transform.position = startPosition;
    }
    #endregion

    // Heh couldve used inheritence so i dont have to copy and paste the same code to AIController.cs but im too lazy
    #region Forehand
    public void Forehand()
    {
        animator.SetTrigger("Forehand");
    }
    #endregion

    #region Backhand
    public void Backhand()
    {
        animator.SetTrigger("Backhand");
    }
    #endregion
}
