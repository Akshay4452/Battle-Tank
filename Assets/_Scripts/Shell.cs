using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Vector3 fireDirection;
    private Rigidbody rb;
    private float life; // Lifespan of bullet
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        life = 5f;
    }

    private void Update()
    {
        life -= Time.deltaTime;
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }
}
