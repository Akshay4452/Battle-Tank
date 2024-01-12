using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController m_tankController;
    private float m_movement;
    private float m_rotation;
    private float movementSpeed;
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        m_movement = Input.GetAxis("Vertical");
        m_rotation = Input.GetAxis("Horizontal");

        if(m_movement != 0)
        {
            m_tankController.Move(m_movement, 30); // Hard-coding movementSpeed for now. TankModel is supposed to hold this value
        }
        if(m_rotation != 0)
        {
            m_tankController.Rotate(m_rotation, 50); // Hard-coding rotationSpeed for now.
        }
    }

    public void SetTankController(TankController controller)
    {
        m_tankController = controller;
    }

    public Rigidbody GetRigidbody()
    {
        if(this.GetComponent<Rigidbody>() != null)
        {
            return GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("Rigidbody couldn't be found on Tank\n");
            return null;
        }
    }
}
