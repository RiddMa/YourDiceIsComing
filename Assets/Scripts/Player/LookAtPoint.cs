using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtPoint : MonoBehaviour
{
    private Camera _mainCamera;

    private RaycastHit _raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var camRay = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(camRay.origin, camRay.direction * 1000, Color.yellow);
        Physics.Raycast(camRay, out _raycastHit);
        // transform.position = new Vector3(_raycastHit.point.x,1.0f,_raycastHit.point.z);
        transform.position = _raycastHit.point;
    }
}
