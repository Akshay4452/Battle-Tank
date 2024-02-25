using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController m_tankController;
    private float m_movement;
    private float m_rotation;
    private bool m_bIsFired;
    [SerializeField] private Transform shellSpawn;

    public MeshRenderer[] tankComponents;
    public GameObject shellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (tankComponents.Length == 0)
        {
            Debug.LogError("Mesh Renderers of Tank Components are Missing\n");
            return;
        }
        if (shellPrefab == null)
        {
            Debug.LogError("Shell Prefab is missing in the inspector\n");
            return;
        }
        Camera mainCam = Camera.main;
        mainCam.transform.SetParent(transform);
        mainCam.transform.position = new Vector3(0f, 3f, -4f); // Relative Position to Tank
        mainCam.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // If LMB is pressed => Fire the shell
        m_bIsFired = Input.GetMouseButtonDown(0);
        if (m_bIsFired)
        {
            Fire();
        }
    }

    private void Movement()
    {
        m_movement = Input.GetAxis("Vertical");
        m_rotation = Input.GetAxis("Horizontal");

        if (m_movement != 0)
        {
            m_tankController.Move(m_movement, m_tankController.GetTankModel().m_movementSpeed);
        }
        if (m_rotation != 0)
        {
            m_tankController.Rotate(m_rotation, m_tankController.GetTankModel().m_rotationSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            collision.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void Fire()
    {
        if (shellSpawn != null)
        {
            GameObject shellInstance = Instantiate(shellPrefab, shellSpawn.position, shellSpawn.rotation);
            Physics.IgnoreCollision(shellInstance.GetComponent<Collider>(), shellSpawn.parent.GetComponent<Collider>());
            //shellInstance.transform.parent = transform; // Making the shell child of tank gameobject

            float forceMagnitude = m_tankController.GetTankModel().m_shellForce;
            Rigidbody shell_rb = shellInstance.GetComponent<Rigidbody>();

            shell_rb.AddForce(shellSpawn.forward * forceMagnitude, ForceMode.Impulse);
        }
        else
        {
            return;
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
