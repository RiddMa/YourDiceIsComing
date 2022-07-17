using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    //float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public Transform shild_transform;
    void Update()
    {
        //// Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        //// Rotate the cube by converting the angles into a quaternion.
        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        //// Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        transform.Rotate(0, Time.deltaTime * tiltAngle, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger Entered");

        Debug.Log(other.gameObject.tag);

        if(other.CompareTag("Player"))
        {
            Debug.Log("Player has Entered");
            Fetched(other.gameObject);
        }
    }

    private void Fetched(GameObject player)
    {
        Destroy(gameObject); // destroy self
    }
}
