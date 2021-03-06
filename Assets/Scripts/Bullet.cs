using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Bullet : MonoBehaviour
{
    private Vector3 velocity;
    public Rigidbody rb = null;
    public string[] filterList = new string[] {""};
    private float impact = 1f;
    private float liveTime = 10f;
    private HashSet<int> targetList = new HashSet<int>();

    public void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Destroy(gameObject, liveTime);
    }

    public void Shoot(Vector3 velocity)
    {
        this.velocity = velocity;
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("target!");
        if (collision.body == null) return;
        if (collision.body.CompareTag("Player") || collision.body.CompareTag("Enemy") || collision.body.CompareTag("Bullet"))
        {
            bool flag = true;
            foreach(string filterString in filterList)
            {
                // filter the specific tag
                if (collision.body.CompareTag(filterString))
                {
                    flag = false;
                    break;
                }
            }
            if (flag && !collision.body.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                var DamageTaken = collision.body.gameObject.GetComponent<IDamageable<float>>();
                int hashCode = DamageTaken.GetHashCode();
                if (targetList.Contains(hashCode)) return;

                int cnt = 0;
                foreach (var con in collision.contacts)
                {
                    Debug.Log("Damage!!!" + (++cnt).ToString());
                    DamageTaken.Damage(51f, impact * (velocity.normalized + Vector3.up * 2), con.point);
                    break;
                }
                targetList.Add(DamageTaken.GetHashCode());
            }
            if (flag && collision.body.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
