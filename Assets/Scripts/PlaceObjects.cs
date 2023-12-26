using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
    public LayerMask layer;
    public float rotateSpeed = 80f;
    private void PositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 1000f, layer))
            transform.position = hit.point;
    }
    private void Start()
    {
        PositionObject();
    }

    public void Update()
    {
        PositionObject();

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject.GetComponent<PlaceObjects>());
        }

        if (Input.GetKey(KeyCode.LeftShift))
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}