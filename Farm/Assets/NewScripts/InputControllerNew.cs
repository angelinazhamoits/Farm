using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControllerNew : MonoBehaviour
{
    private PersonControllerNew _personController;
    
    #region  InputAction

    private PlayerInput _inputController;
    private InputAction _actionMove;
    private InputAction _actionJump;
    #endregion

    private void Awake()
    {
        _inputController = GetComponent<PlayerInput>();
        _personController = GetComponent<PersonControllerNew>();

        _actionMove = _inputController.actions["Move"];
        _actionJump = _inputController.actions["Jump"];  

    }

    private void Update()
    {
        Moved();
        Jumping();
    }

    private void Jumping()
    {
        if (_actionJump.triggered)
        {
            _personController.isJump = true;
        }
    }

    private void Moved()
    {
        Vector2 input = _actionMove.ReadValue<Vector2>();
        _personController.MoveIput = input;
    }

   
}
