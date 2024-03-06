using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController m_tankController;
    private float m_movement;
    private float m_rotation;
    private bool m_bIsFired;
    [SerializeField] private Transform shellSpawn;
    [SerializeField] private Transform shellFireSpawn;

    public MeshRenderer[] tankComponents;
    public Shell shellPrefab;
    public ParticleSystem shellFireEffect;

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
        if(shellFireEffect == null)
        {
            Debug.LogError("Shell Fire Effect particle system is missing in the inspector\n");
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
        if (m_bIsFired && m_movement == 0)
        {
            Fire(); // Fire only when tank is stationary
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

        if (m_rotation == 0)
        {
            if (AudioManager.Instance.IsSoundPlaying(SoundType.TankTurretRotate))
                AudioManager.Instance.Stop(SoundType.TankTurretRotate);
        }

        if (m_movement == 0)
        {
            if (AudioManager.Instance.IsSoundPlaying(SoundType.TankMovement))
                AudioManager.Instance.Stop(SoundType.TankMovement);
        }

        
    }

    private void Fire()
    {
        m_tankController.FireShell();
        GameObject fireEffect = Instantiate(shellFireEffect.gameObject, shellFireSpawn.position, shellFireSpawn.rotation);
        Destroy(fireEffect, 0.5f);
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

    public Transform GetShellSpawnTransform()
    {
        return shellSpawn;
    }
}
