using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
