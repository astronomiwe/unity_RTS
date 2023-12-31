using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCarCreate : MonoBehaviour
{
    [NonSerialized] public bool IsEnemy = false;
    [NonSerialized] public bool IsBuilded = false;
    public GameObject car;
    public float time = 5f;
    
    
    public void StartSpawningCars() 
    {
        StartCoroutine(SpawnCar());
    }
    
    IEnumerator SpawnCar()
    {
        // создает 3 машинки в радиусе от месте спавна у здания
            for (int i = 1; i <= 3; i++)
            {
                yield return new WaitForSeconds(time);
                Vector3 pos = new Vector3(
                    transform.GetChild(0).position.x + UnityEngine.Random.Range(4f, 10f),
                    transform.GetChild(0).position.y,
                    transform.GetChild(0).position.z + UnityEngine.Random.Range(4f, 10f)
                );
                GameObject spawned = Instantiate(car, pos, Quaternion.identity);

                if (IsEnemy)
                    spawned.tag = "enemy";
            }
    }
}
