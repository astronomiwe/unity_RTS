using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 20f, damage = 12.5f; // все снаряды сейчас одинаковые. вынести в скрипт Damage? как Health.

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
