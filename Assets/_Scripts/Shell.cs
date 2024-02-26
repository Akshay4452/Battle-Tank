using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private float life; // Lifespan of bullet
    void Start()
    {
        life = 5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy bullet when hit to another object
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
