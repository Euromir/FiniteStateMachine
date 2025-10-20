using UnityEngine;

public class DiscoRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;

    private Vector3 rotationY = Vector3.up;
    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationY, rotationAmount, Space.World);
    }
}
