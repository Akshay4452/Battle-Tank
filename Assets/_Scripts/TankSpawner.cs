using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView m_tankView;

    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public TankTypes tankType;
        public Material color;
    }

    public List<Tank> tankList;

    void Start()
    {
        if (m_tankView == null)
            Debug.LogError("Tank Prefab is Empty\n");

        CreateTank(); // Tank instantiation is handled by TankController script
    }

    private void CreateTank()
    {
        // By default, Green Tank will spawn -> Currently there is no UI set
        Tank tank = tankList[0];
        TankModel tankModel = new TankModel(tank.movementSpeed, tank.rotationSpeed, tank.tankType, tank.color);
        TankController tankController = new TankController(tankModel, m_tankView);
    }
}
