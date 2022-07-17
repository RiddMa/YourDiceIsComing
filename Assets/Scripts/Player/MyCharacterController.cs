using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MyCharacterController : MonoBehaviour
{
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;
    [FormerlySerializedAs("speed")] public float magnitude = 1000f;

    private PlayerControls _playerControls;
    private InputAction _moveInput;

    private Camera _mainCamera;
    public Vector3 cameraOffset = new Vector3(0, 10, -10);

    public GameObject playerTurret;
    public GameObject bulletTypeGameObject;
    public float bulletSpeed = 20f;
    private Transform _turretSocketTransform;

    public float health;
    public GameObject healthUI;
    public GameObject explosiveDebris;

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

        var cm = GameObject.FindGameObjectWithTag("PlayerCM");
        var vCam = cm.GetComponent<CinemachineVirtualCamera>();
        var selfTransform = transform;
        vCam.gameObject.SetActive(false);
        vCam.Follow = selfTransform;
        vCam.LookAt = selfTransform;

        var body = vCam.GetCinemachineComponent<CinemachineTransposer>();
        body.m_FollowOffset = cameraOffset;
        body.m_BindingMode = CinemachineTransposer.BindingMode.WorldSpace;
        vCam.ForceCameraPosition(cameraOffset, Quaternion.identity);
        var aim = vCam.GetCinemachineComponent<CinemachineComposer>();
        aim.m_LookaheadTime = 0.1f;
        aim.m_LookaheadSmoothing = 1.0f;
        vCam.gameObject.SetActive(true);
        _turretSocketTransform = playerTurret.transform.Find("Socket");

        healthUI = GameObject.Find("Canvas/Health");
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Fire(InputAction.CallbackContext context)
    {
        var rot = playerTurret.transform.rotation;
        var bullet = Instantiate(bulletTypeGameObject, _turretSocketTransform.position, rot);
        var bulletSpeedVector = bulletSpeed * playerTurret.transform.forward;
        bullet.GetComponent<Bullet>().Shoot(bulletSpeedVector);
    }

    private void Start()
    {
    }

    private void Update()
    {
        var movement = _moveInput.ReadValue<Vector2>();

        _movementX = movement.x;
        _movementY = movement.y;

        // transform.position = _rb.transform.position;
    }

    private void FixedUpdate()
    {
        MoveCharacter(new Vector3(_movementX, 0.0f, _movementY));
    }

    private void MoveCharacter(Vector3 direction)
    {
        // _rb.velocity = speed * Time.fixedDeltaTime * direction;
        // _rb.AddForce(magnitude * Time.fixedDeltaTime * direction, ForceMode.Force);
        // _rb.AddForce(magnitude * direction, ForceMode.Force);
        // _rb.velocity;
        _rb.AddForceAtPosition(magnitude * Mathf.Pow(2.7f, -_rb.velocity.magnitude) * direction,
            transform.position + new Vector3(0, 1, 0));
    }

    private void SetCharacterLookAtCursor()
    {
    }

    public void Kill()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        Instantiate(explosiveDebris, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        health -= damage;
        healthUI.GetComponent<HealthDisplay>().SetHealth(health);
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Damage(float damage, Vector3 impactForce, Vector3 impactPoint)
    {
        _rb.AddForceAtPosition(impactForce, impactPoint, ForceMode.Impulse);
        health -= damage;
        healthUI.GetComponent<HealthDisplay>().SetHealth(health);
        if (health <= 0)
        {
            Kill();
        }
    }
}