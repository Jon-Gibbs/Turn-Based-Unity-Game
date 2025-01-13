using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputLogic : MonoBehaviour
{
    public static Vector2 Movement;

    private PlayerInput playerInput;
    private InputAction movaAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movaAction = playerInput.actions["Move"];
    }
    // Update is called once per frame
   private void Update()
    {
        Movement = movaAction.ReadValue<Vector2>();
    }
}
