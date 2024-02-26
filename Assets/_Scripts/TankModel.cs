using UnityEngine;

public class TankModel
{
    private TankController m_tankController;

    public float m_movementSpeed;
    public float m_rotationSpeed;
    public TankTypes m_tankType;
    public Material m_color;
    private float m_fireDelay; // Time interval between two shots
    public float m_shellForce; // Force at which shell is fired 

    public TankModel(float movementSpeed, float rotationSpeed, TankTypes tankType, Material color, float fireDelay)
    {
        m_movementSpeed = movementSpeed;
        m_rotationSpeed = rotationSpeed;
        m_tankType = tankType;
        m_color = color;
        m_fireDelay = fireDelay;
        m_shellForce = 50f; // Making shell force as 100 units
    }

    public void SetTankController(TankController controller)
    {
        m_tankController = controller;
    }
}
