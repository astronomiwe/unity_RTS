using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CarAttack : MonoBehaviour
{
    public float radius = 70f;
    public GameObject bullet;
    private Coroutine _coroutine;
    public float minDistance = 60f; // Минимальное расстояние, на которое можно приблизиться к цели

    private void Update()
    {
        DetectCollation();
    }

    private void DetectCollation()
    {
        // определяет, что в радиусе есть обьекты
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        if (hitColliders.Length == 0 && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;

            if (gameObject.CompareTag("enemy"))
                // если текущий обьект враг и он был уничтожен (длина 0), останавливаемся
                GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
        }

        foreach (var el in hitColliders)
        {
            // проверка, что обьект является противником
            if (
                (gameObject.CompareTag("Player") && el.gameObject.CompareTag("enemy")) ||
                (gameObject.CompareTag("enemy") && el.gameObject.CompareTag("Player"))
            )
            {
                if (_coroutine == null)
                    _coroutine = StartCoroutine(StartAttack(el));
                
                if (Vector3.Distance(transform.position, el.transform.position) > minDistance) 
                    if (gameObject.CompareTag("enemy"))
                        GetComponent<NavMeshAgent>().SetDestination(el.transform.position);


            }
        }
    }

    IEnumerator StartAttack(Collider enemy)
    {
        // выпускает пули по обьекту
        GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
        obj.GetComponent<BulletController>().position = enemy.transform.position;
        yield return new WaitForSeconds(1f);

        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}