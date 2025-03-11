using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cube;
    public Vector3 offset = new Vector3(0, 1.5f, -5);
    public float rotationSpeed = 100.0f; // Sensitivitas lebih tinggi
    public float sensitivityMultiplier = 6f; // Faktor tambahan untuk meningkatkan responsivitas
    private Vector3 lastMousePosition;

    void LateUpdate()
    {
        if (cube != null)
        {
            transform.position = cube.transform.position + cube.transform.rotation * offset;
            transform.LookAt(cube.transform.position);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;

            // Perbesar sensitivitas dengan faktor tambahan
            float rotateX = deltaMouse.x * rotationSpeed * sensitivityMultiplier * 0.01f;
            float rotateY = -deltaMouse.y * rotationSpeed * sensitivityMultiplier * 0.01f;

            cube.transform.Rotate(Vector3.up, rotateX, Space.World);
            cube.transform.Rotate(Vector3.right, rotateY, Space.Self);

            lastMousePosition = Input.mousePosition;
        }
    }
}
