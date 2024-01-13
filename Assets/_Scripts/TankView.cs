using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController m_tankController;
    private float m_movement;
    private float m_rotation;

    public MeshRenderer[] tankComponents;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCam = Camera.main;
        mainCam.transform.SetParent(transform);
        mainCam.transform.position = new Vector3(0f, 3f, -4f); // Relative Position to Tank
        mainCam.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
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
            m_tankController.Move(m_movement, m_tankController.GetTankModel().m_movementSpeed);
        }
        if(m_rotation != 0)
        {
            m_tankController.Rotate(m_rotation, m_tankController.GetTankModel().m_rotationSpeed);
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

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < tankComponents.Length; i++)
        {
            tankComponents[i].material = color;
        }
    }
}
