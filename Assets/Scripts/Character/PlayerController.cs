using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _xInput, _yInput;

    private Vector2 _movement;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public bool moving;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        HandleMovementInput();
        HandleAnimation();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void HandleMovementInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
        _movement = new Vector3(_xInput, _yInput,0).normalized;

        if (_xInput != 0 || _yInput != 0)
        {
            moving = true;
            return;
        }
        moving = false;
    }
    private void Move()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * _speed * Time.fixedDeltaTime);
    }
    private void HandleAnimation()
    {
        _animator.SetBool("move", moving);
    }

    public void ChangeSpeed(float speed)
    {
        this._speed = speed;
    }

}
