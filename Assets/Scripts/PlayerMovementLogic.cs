using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(InputLogic.Movement.x, InputLogic.Movement.y);
        rb.velocity = movement * moveSpeed;
    }
}
