using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurret : MonoBehaviour
{
    private Camera _mainCamera;
    private RaycastHit _raycastHit;

    public GameObject followGameObject;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        followGameObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var camRay = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(camRay.origin, camRay.direction * 1000, Color.yellow);
        Physics.Raycast(camRay, out _raycastHit);
        transform.LookAt(new Vector3(_raycastHit.point.x,transform.position.y,_raycastHit.point.x));
        // transform.position = followGameObject.transform.position;
    }
}
