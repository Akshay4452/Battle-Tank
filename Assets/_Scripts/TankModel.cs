using UnityEngine;

public class TankModel
{
    private TankController m_tankController;

    public TankModel()
    {

    }

    public void SetTankController(TankController controller)
    {
        m_tankController = controller;
    }
}
