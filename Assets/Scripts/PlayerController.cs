using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary { 
    public float xMin,xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float titl;

    public Boundary boundary;

    public GameObject bullet;
    public Transform bulletTransform;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
        }
    }
    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3 (horizontal, 0, vertical) * speed;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
        );

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -titl);
    }


}
