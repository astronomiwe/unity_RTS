using UnityEngine;
public class CameraControl: MonoBehaviour
{
    public float rotateSpeed = 40f, speed = 15f, zoomSpeed = 50f;

    private float _mult = 1f;
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float rotate = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotate = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotate = 1f;
        }

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        transform.Rotate(Vector3.up * rotateSpeed * rotate * Time.deltaTime * _mult, Space.World);
        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * _mult * speed, Space.Self);

        transform.position += transform.up * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(
                transform.position.x, 
                Mathf.Clamp(transform.position.y, -20f, 30f), 
                transform.position.z
            );
    }   

}