using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public int damage = 1;
    public Rigidbody rb;
    private void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
