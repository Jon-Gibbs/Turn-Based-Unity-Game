using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;
    private float variableSpeed;

    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // movement.Set(InputLogic.Movement.x, InputLogic.Movement.y);
        //rb.velocity = movement * moveSpeed;

      //  movement.Set(Input.mousePosition.x, Input.mousePosition.y);
       // rb.velocity = movement * moveSpeed;
      
        /*partial chat gpt code, I have brought shame upon my family*/
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        variableSpeed = Mathf.Abs(rb.position.x - mouseWorldPosition.x) + Mathf.Abs(rb.position.y - mouseWorldPosition.y);
        mouseWorldPosition.z = 0; // Ensure movement stays in 2D

        Vector2 direction = (mouseWorldPosition - transform.position).normalized; // Direction to move
        rb.velocity = direction * moveSpeed * variableSpeed;

    }
}
