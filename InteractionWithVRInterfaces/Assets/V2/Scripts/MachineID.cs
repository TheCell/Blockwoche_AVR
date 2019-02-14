using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineID : MonoBehaviour
{
    [SerializeField] private int machineID;

    public int GetMachineID()
    {
        return this.machineID;
    }
}