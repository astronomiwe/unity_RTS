using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AddBuilding : MonoBehaviour
{
    public GameObject building;
    public void PlaceBuild()
    {
        Instantiate(building, Vector3.zero, Quaternion.identity);
    }
}