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
    private bool hasKilled = false;

    private float m_Timer = 1.0f;

    public void Kill()
    {
        Debug.Log("killed" + transform.position.ToString());
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if(transform.position.y < 2.4f)
        {
            transform.position = new Vector3(transform.position.x, 2.4f, transform.position.z);
        }
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
        rb.AddForceAtPosition(impactForce, impactPoint, ForceMode.Impulse);
        healthPoint -= damage * (1 - defence);
        if (!hasKilled && healthPoint < 0f)
        {
            hasKilled = true;
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
