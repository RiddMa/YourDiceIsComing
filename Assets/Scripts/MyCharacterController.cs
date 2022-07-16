using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MyCharacterController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;
    [FormerlySerializedAs("speed")] public float magnitude = 1000f;

    private PlayerControls _playerControls;
    private InputAction _moveInput;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerInput = GetComponent<PlayerInput>();
        _moveInput = _playerInput.actions["jump"];
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _moveInput = _playerControls.Player.Move;
        _playerControls.Player.Fire.performed += Fire;
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
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var movement = _moveInput.ReadValue<Vector2>();
        if (movement != Vector2.zero)
        {
            Debug.Log("Movement values:" + movement);
        }

        _movementX = _moveInput.ReadValue<Vector2>().x;
        _movementY = _moveInput.ReadValue<Vector2>().y;
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
        if (direction != Vector3.zero)
        {
            Debug.Log((magnitude * Time.fixedDeltaTime * direction).ToString());
        }
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