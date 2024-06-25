using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions _inputActions;

    private InputAction _moveAction;
    private InputAction _lookAction;

    private Rigidbody2D _rb;

    private float _playerSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new InputActions();

        _moveAction = _inputActions.Player.Move;
        _moveAction.Enable();
        _lookAction = _inputActions.Player.Look;
        _lookAction.Enable();

        _inputActions.Player.Fire.Enable();

        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        Vector2 vel = _rb.velocity;
        vel.x = _playerSpeed * moveDir.x;
        vel.y = _playerSpeed * moveDir.y;
        _rb.velocity = vel;
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _inputActions.Player.Fire.Disable();
    }
}
