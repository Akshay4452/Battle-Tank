using UnityEngine;

public class TankModel
{
    private TankController m_tankController;

    public float m_movementSpeed;
    public float m_rotationSpeed;
    public TankTypes m_tankType;
    public Material m_color;

    public TankModel(float movementSpeed, float rotationSpeed, TankTypes tankType, Material color)
    {
        m_movementSpeed = movementSpeed;
        m_rotationSpeed = rotationSpeed;
        m_tankType = tankType;
        m_color = color;
    }

    public void SetTankController(TankController controller)
    {
        m_tankController = controller;
    }
}
