using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpawner tankSpawner;

    private void Start()
    {
        if(tankSpawner == null)
        {
            Debug.LogError("TankSpawner game object is not present\n");
        }
    }

    public void GreenTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.RedTank);
        this.gameObject.SetActive(false);
    }
}
