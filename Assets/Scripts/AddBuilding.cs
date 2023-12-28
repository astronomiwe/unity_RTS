using UnityEngine;

public class AddBuilding : MonoBehaviour
{
    public GameObject building;
    private GameObject currentBuildingInstance;

    public void PlaceBuild()
    {
        currentBuildingInstance = Instantiate(building, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBuildingInstance != null)
        {
            // ставим здание по ЛКМ и запускаем его функционал (спавн машинок)
            AutoCarCreate autoCarCreate = currentBuildingInstance.GetComponent<AutoCarCreate>();
            if (autoCarCreate != null)
            {
                autoCarCreate.StartSpawningCars();
            }
            currentBuildingInstance = null;
        }
        
        if (Input.GetMouseButtonDown(1) && currentBuildingInstance != null)
            // отменяем установку здания по нажатию ПКМ
            Destroy(currentBuildingInstance);

    }
}
