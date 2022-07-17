using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Health : MonoBehaviour, IDamageable<float>, IKillable
{
    public float healthPoint = 100.0f;
    public float defence = 0.00f;
    public GameObject Explosive_debris;
    public GameObject Icon;
    Rigidbody rb = null;

    private float m_Timer = 1.0f;

    public void Kill()
    {
        Debug.Log("killed");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Instantiate(Explosive_debris, transform.position, transform.rotation);
        Instantiate(Icon, transform.position, transform.rotation);
        Destroy(gameObject);
        // explosion
    }

    public void Damage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float damage, Vector3 impactForce, Vector3 impactPoint)
    {
        rb.AddForceAtPosition(impactForce, impactPoint, ForceMode.VelocityChange);
        healthPoint -= damage * (1 - defence);
        if (healthPoint < 0f)
        {
            Kill();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
        if (collision.body != null && collision.body.CompareTag("Player"))
        {
            Debug.Log("Player!");
            foreach (ContactPoint contact in collision.contacts)
            {
                //Debug.DrawRay(contact.point, contact.normal, Color.white);
                Damage(21.0f, contact.normal * 10, contact.point);
            }
        }
    }
}
