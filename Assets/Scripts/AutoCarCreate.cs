using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCarCreate : MonoBehaviour
{
    public GameObject car;
    public float time = 5f;

    public void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        for (int i = 1; i <= 3; i++)
        {
            yield return new WaitForSeconds(time);
            Instantiate(car, transform.GetChild(0).position, Quaternion.identity);
        }
    }
}
