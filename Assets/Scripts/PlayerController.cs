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

    private Animator _animator;
    private Animator _animatorOutfit1;

    private float _playerSpeed = 2;

    private UIController _ui;

    private int _gold;
    public int Gold
    {
        get { return _gold; }
        set
        {
            if (_gold == value) return;
            _gold = value;
            if (OnGoldChange != null)
                OnGoldChange(_gold);
        }
    }
    public delegate void OnGoldChangeDelegate(int newVal);
    public event OnGoldChangeDelegate OnGoldChange;


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

        _animator = GetComponent<Animator>();
        _animatorOutfit1 = GetComponentInChildren<Animator>();

        _gold = 100;
        _ui = FindObjectOfType<UIController>();
        OnGoldChange += _ui.GoldChangeHandler;
    }

    private void FixedUpdate()
    {
        //Player movement
        Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        Vector2 vel = _rb.velocity;

        vel.x = _playerSpeed * moveDir.x;
        vel.y = _playerSpeed * moveDir.y;
        _rb.velocity = vel;

        //Animation
        if(vel.sqrMagnitude > 0.01) //To determine idle facing direction
        {
            _animator.SetFloat("LastHor", vel.x);
            _animator.SetFloat("LastVert", vel.y);
        } 

        _animator.SetFloat("Horizontal", vel.x);
        _animator.SetFloat("Vertical", vel.y);
        _animator.SetFloat("Speed", vel.sqrMagnitude);
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _inputActions.Player.Fire.Disable();

        OnGoldChange -= _ui.GoldChangeHandler;
    }
}
