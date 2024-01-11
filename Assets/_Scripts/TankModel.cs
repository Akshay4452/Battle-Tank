using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public TankModel()
    {

    }

    public void SetTankController(TankController controller)
    {
        tankController = controller;
    }
}
