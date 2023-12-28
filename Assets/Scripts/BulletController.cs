using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 30f, damage = 12.5f; // все пули сейчас наносят 12.5 дамага. вынести как Health в скрипт?

    private void Update()
    {
        // посылает пулю к обьекту
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
        
        if (transform.position==position)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("Player"))
            other.GetComponent<Health>().TakeDamage(damage);
    }
}
