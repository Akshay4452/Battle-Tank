using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel model, TankView view)
    {
        tankModel = model;
        tankView = view;

        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        GameObject.Instantiate(tankView.gameObject); // No need to setup position and rotation
    }
}
