using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AddBuilding : MonoBehaviour
{
    public GameObject building;
    private GameObject currentBuildingInstance;

    public void PlaceBuild()
    {
        // Создаем экземпляр здания
        currentBuildingInstance = Instantiate(building, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        // Проверяем нажатие левой кнопки мыши и наличие здания, ожидающего установки
        if (Input.GetMouseButtonDown(0) && currentBuildingInstance != null)
        {
            AutoCarCreate autoCarCreate = currentBuildingInstance.GetComponent<AutoCarCreate>();
            if (autoCarCreate != null)
            {
                autoCarCreate.StartSpawningCars();
            }
            // Сбросить текущий экземпляр здания, так как он уже установлен
            currentBuildingInstance = null;
        }
    }
}
