using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarAttack : MonoBehaviour
{
    public float radius = 70f;
    public GameObject bullet;
    private Coroutine _coroutine;

    private void Update()
    {
        DetectCollation();
    }

    private void DetectCollation()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        if (hitColliders.Length == 0)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        foreach (var el in hitColliders)
        {
            if (
                (gameObject.CompareTag("Player") && el.gameObject.CompareTag("enemy")) ||
                (gameObject.CompareTag("enemy") && el.gameObject.CompareTag("Player"))
            )
            {
                if (gameObject.CompareTag("enemy"))
                    GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(el.transform.position);
                
                if (_coroutine == null)
                    _coroutine = StartCoroutine(StartAttack(el));
            }
        }
    }

    IEnumerator StartAttack(Collider enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
            obj.GetComponent<BulletController>().position = enemy.transform.position;
        }
    }
}