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
        public float fireDelay;
    }

    public List<Tank> tankList;

    void Start()
    {
        if (m_tankView == null)
        {
            Debug.LogError("Tank Prefab is not Assigned in Tank Spawner\n");
            return;
        }
    }

    public void CreateTank(TankTypes tankType)
    {
        Tank tank = null;
        switch (tankType)
        {
            case TankTypes.GreenTank:
                tank = tankList[0];
                break;
            case TankTypes.BlueTank:
                tank = tankList[1];
                break;
            case TankTypes.RedTank:
                tank = tankList[2];
                break;
            default:
                tank = tankList[0];
                break;
        }

        TankModel tankModel = new TankModel(tank.movementSpeed, tank.rotationSpeed, tank.tankType, tank.color, tank.fireDelay);
        TankController tankController = new TankController(tankModel, m_tankView);
    }
}
