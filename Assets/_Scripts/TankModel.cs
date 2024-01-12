using UnityEngine;

public class TankModel
{
    private TankController m_tankController;

    public float m_movementSpeed;
    public float m_rotationSpeed;

    public TankModel(float movementSpeed, float rotationSpeed)
    {
        m_movementSpeed = movementSpeed;
        m_rotationSpeed = rotationSpeed;
    }

    public void SetTankController(TankController controller)
    {
        m_tankController = controller;
    }
}
