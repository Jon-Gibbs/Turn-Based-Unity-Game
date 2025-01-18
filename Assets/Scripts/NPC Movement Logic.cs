using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementLogic : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    [SerializeField] float travelDistance;
    Vector3 initialPosition;
    private bool movingLeft = true;
    private bool isWaiting = false;
    // saves the initial position of the object to a given position
    void Start()
    {
       initialPosition = transform.position;
    }

    // makes the object move back and forth with the radius set by travel distance
    void Update()
    {
        if(isWaiting) return;
        if (movingLeft)
        {
            if (transform.position.x > initialPosition.x - travelDistance)
            {

                transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(waitAndSwitch(false));
            }
        }
        else
        {
            if(transform.position.x < initialPosition.x + travelDistance)
            {
                transform.position += (Vector3.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(waitAndSwitch(true));
            }
        }
    }

    //pauses the object's movement and flips the sprite render direction
    IEnumerator waitAndSwitch(bool toLeft)
    {
        isWaiting = true;
        animator.SetFloat("Speed", 0f);
        yield return new WaitForSeconds(1f);
        animator.SetFloat("Speed", moveSpeed);
        movingLeft = toLeft;
        spriteRenderer.flipX = spriteRenderer.flipX ? false : true;
        isWaiting = false;
    }
}
