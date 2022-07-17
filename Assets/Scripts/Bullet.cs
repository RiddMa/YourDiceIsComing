using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Bullet : MonoBehaviour
{
    private Vector3 velocity;
    public Rigidbody rb = null;
    private float impact = 10;

    public void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void shoot(Vector3 velocity)
    {
        this.velocity = velocity;
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.body == null) return;
        if (collision.body.CompareTag("Player") || collision.body.CompareTag("Enemy"))
        {
            var DamageTaken = collision.body.gameObject.GetComponent<IDamageable<float>>();
            foreach(var con in collision.contacts)
            {
                DamageTaken.Damage(51f, impact * velocity.normalized, con.point);
            }
        }
    }
}
