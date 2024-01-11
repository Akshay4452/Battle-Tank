using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    void Start()
    {
        if (tankView == null)
            Debug.LogError("Tank Prefab is Empty\n");

        CreateTank(); // Tank instantiation is handled by TankController script
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel();
        TankController tankController = new TankController(tankModel, tankView);
    }
}
