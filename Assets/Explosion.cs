using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody[] lz = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in lz)
        {
            rb.AddExplosionForce(500f, transform.position, 5);
            Destroy(rb.gameObject, 5f);
            Debug.Log(rb.gameObject.ToString());
        }
        Debug.Log("Destroy");
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
