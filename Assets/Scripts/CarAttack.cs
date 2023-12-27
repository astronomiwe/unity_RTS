using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttack : MonoBehaviour
{
    public float radius = 70f;

    private void Update()
    {
        DetectCollation();
    }

    private void DetectCollation()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var el in hitColliders)
        {
            if(
                (gameObject.CompareTag("Player") && el.gameObject.CompareTag("enemy")) ||
                (gameObject.CompareTag("enemy") && el.gameObject.CompareTag("Player"))
                )
                Debug.Log(el.name);
        }
    }
}
