using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView m_tankView;
    void Start()
    {
        if (m_tankView == null)
            Debug.LogError("Tank Prefab is Empty\n");

        CreateTank(); // Tank instantiation is handled by TankController script
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(30, 50);
        TankController tankController = new TankController(tankModel, m_tankView);
    }
}
