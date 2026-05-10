using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    public float speed = 180f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
