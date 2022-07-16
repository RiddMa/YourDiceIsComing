using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MyCharacterController : MonoBehaviour, IKillable, IDamageable<float>
{
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;
    [FormerlySerializedAs("speed")] public float magnitude = 1000f;

    private PlayerControls _playerControls;
    private InputAction _moveInput;

    private Camera _mainCamera;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _moveInput = _playerControls.Player.Move;
        _playerControls.Player.Fire.performed += Fire;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fired");
    }

    private void Start()
    {
    }

    private void Update()
    {
        var movement = _moveInput.ReadValue<Vector2>();

        _movementX = movement.x;
        _movementY = movement.y;
    }

    private void FixedUpdate()
    {
        MoveCharacter(new Vector3(_movementX, 0.0f, _movementY));
    }

    private void MoveCharacter(Vector3 direction)
    {
        // _rb.velocity = speed * Time.fixedDeltaTime * direction;
        // _rb.AddForce(magnitude * Time.fixedDeltaTime * direction, ForceMode.Force);
        _rb.AddForce(magnitude * direction, ForceMode.Force);
        _rb.AddForceAtPosition(magnitude * direction, transform.position + new Vector3(0, 1, 0));


        // if (direction != Vector3.zero)
        // {
        //     Debug.Log((magnitude * Time.fixedDeltaTime * direction).ToString());
        // }
    }

    private void SetCharacterLookAtCursor()
    {
    }

    public void Kill()
    {
    }

    public void Damage(float damage)
    {
        throw new NotImplementedException();
    }

    public void Damage(float damage, Collision hitResult)
    {
    }

    // private PlayerControls _playerControls;
    //
    // private void Awake()
    // {
    //     _playerControls = new PlayerControls();
    // }
    //
    // private void OnEnable()
    // {
    //     _playerControls.Enable();
    //     _playerControls.Player.Fire.performed += Fired;
    // }
    //
    // private void OnDisable()
    // {
    //     _playerControls.Player.Fire.performed -= Fired;
    //     _playerControls.Disable();
    //     
    // }
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // private void Fired(InputAction.CallbackContext context)
    // {
    //     Debug.Log("Fired");
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     Vector2 move = _playerControls.Player.Move.ReadValue<Vector2>();
    //     // Debug.Log(move);
    //     bool jump = _playerControls.Player.Jump.triggered;
    //     if (jump)
    //     {
    //         Debug.Log("jump");
    //     }
    // }
}