using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SelectController : MonoBehaviour
{
    public GameObject cube;
    public LayerMask layer, layerMask;
    public List<GameObject> selectedObjects;
    private Camera _cam;
    private GameObject _cubeSelection;
    private RaycastHit _hit;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && selectedObjects.Count > 0)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer)) ;
            foreach (var el in selectedObjects)
                el.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(agentTarget.point);
        }


        if (Input.GetMouseButtonDown(0))
        {
            foreach (var el in selectedObjects)
                if (el != null)
                    el.transform.GetChild(0).gameObject.SetActive(false);

            selectedObjects.Clear();

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit, 1000f, layer))
                _cubeSelection = Instantiate(cube, new Vector3(_hit.point.x, 1, _hit.point.z), Quaternion.identity);
        }

        if (_cubeSelection)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitDrag, 1000f, layer))
            {
                float xScale = (_hit.point.x - hitDrag.point.x) * -1;
                float zScale = _hit.point.z - hitDrag.point.z;
                Vector3 _Vector;

                // обработка случаев с отрицательными значениями длин параллелограмма селектора 
                if (xScale < 0.0f && zScale < 0.0f)
                    _Vector = new Vector3(0, 180, 0);
                else if (xScale < 0.0f)
                    _Vector = new Vector3(0, 0, 180);
                else if (zScale < 0.0f)
                    _Vector = new Vector3(180, 0, 0);
                else
                    _Vector = new Vector3(0, 0, 0);

                _cubeSelection.transform.localRotation = Quaternion.Euler(_Vector);

                _cubeSelection.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, Mathf.Abs(zScale));
            }

            if (Input.GetMouseButtonUp(0) && _cubeSelection)
            {
                RaycastHit[] hits = Physics.BoxCastAll(
                    _cubeSelection.transform.position,
                    _cubeSelection.transform.localScale,
                    Vector3.up,
                    Quaternion.identity,
                    0,
                    layerMask
                );
                foreach (var el in hits)
                {
                    if (el.collider.CompareTag("enemy")) continue;

                    selectedObjects.Add(el.transform.gameObject);
                    el.transform.GetChild(0).gameObject.SetActive(true);
                }

                Destroy(_cubeSelection);
            }
        }
    }
}