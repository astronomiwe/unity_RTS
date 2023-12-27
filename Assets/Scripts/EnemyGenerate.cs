using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public Transform[] points;
    public GameObject factory;

    public void Start()
    {
        StartCoroutine(SpawnFactory());
    }

    IEnumerator SpawnFactory()
    {
        // генератор зданий в точках, указанных в списке points
        for (int i = 0; i < points.Length; i++)
        {
            yield return new WaitForSeconds(10f);
            GameObject spawned = Instantiate(factory);
            Destroy(spawned.GetComponent<PlaceObjects>());
            spawned.transform.position = points[i].position;
            spawned.transform.rotation = Quaternion.Euler(
                new Vector3(0, UnityEngine.Random.Range(0, 360), 0)
                );
            spawned.GetComponent<AutoCarCreate>().enabled = true;
            spawned.GetComponent<AutoCarCreate>().IsEnemy = true;
            
            // здесь должна быть общий метод действий для здания.
            // оно же не только машинки генерирует.
            // кандидат в рефакторинг.
            spawned.GetComponent<AutoCarCreate>().StartSpawningCars(); 

        }
    }
}
