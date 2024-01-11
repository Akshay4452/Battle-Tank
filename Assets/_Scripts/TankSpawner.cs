using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public GameObject tankPrefab;
    void Start()
    {
        if (tankPrefab == null)
            Debug.LogError("Tank Prefab is Empty\n");

        Instantiate(tankPrefab, transform.position, Quaternion.identity);
    }
}
