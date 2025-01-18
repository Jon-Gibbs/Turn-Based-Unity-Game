using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotLogic : MonoBehaviour
{
    private float launchVelocity;
    private Vector2 launchDirection; // make me this vector by drawing a point between the mouse and the launch item
    private Vector3 mousePosition;
    public float launchSpeedMultiplier;
    [SerializeField] Rigidbody2D launchItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0)) {
            launchVelocity = Mathf.Abs(launchItem.position.x - mousePosition.x) + Mathf.Abs(launchItem.position.y - mousePosition.y);
            //you have set the velocity, now launch

        }
    }
    //if the mouse input button is down, measure the distance between the mouse position and the player
    //once released, give the player the velocity created by the previous statement
}
