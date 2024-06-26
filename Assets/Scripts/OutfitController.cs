using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

public class OutfitController : MonoBehaviour
{
    private MyActions _inputActions;
    public PlayerInput _pI;

    private InputAction _moveAction;

    private Animator _animator;

    private SpriteLibrary _spriteLibrary;
    public SpriteLibraryAsset[] _outfits;
    private bool[] outfitsOwned = { false, false, false };

    private float _playerSpeed = 2;

    private UIController _ui;

    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new MyActions();

        _moveAction = _inputActions.Player.Move;
        _moveAction.Enable();

        _inputActions.Player.Fire.Enable();

        _spriteLibrary = GetComponent<SpriteLibrary>();

        _animator = GetComponent<Animator>();
        //_animatorOutfit = GetComponentInChildren<Animator>();

        _ui = FindObjectOfType<UIController>();

        _rb = GetComponent<Rigidbody2D>();

        _animator.SetFloat("LastHor", 0);
        _animator.SetFloat("LastVert", 1);
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
        if (vel.sqrMagnitude > 0.01) //To determine idle facing direction
        {
            _animator.SetFloat("LastHor", vel.x);
            _animator.SetFloat("LastVert", vel.y);
            //_animatorOutfit.SetFloat("LastHor", vel.x);
            //_animatorOutfit.SetFloat("LastVert", vel.y);
        }

        _animator.SetFloat("Horizontal", vel.x);
        _animator.SetFloat("Vertical", vel.y);
        _animator.SetFloat("Speed", vel.sqrMagnitude);
        //_animatorOutfit.SetFloat("Horizontal", vel.x);
        //_animatorOutfit.SetFloat("Vertical", vel.y);
        //_animatorOutfit.SetFloat("Speed", vel.sqrMagnitude);
    }

    private void OnDisable()
    {
        _moveAction.Disable();
    }

    public void ChangeOutfit(int outfitID)
    {
        _spriteLibrary.spriteLibraryAsset = _outfits[outfitID];
    }
}
