using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 7.5f;
    [SerializeField]

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
