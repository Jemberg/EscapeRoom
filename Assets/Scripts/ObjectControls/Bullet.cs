using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public Vector3 direction { get; set; }

    public float m_Thrust = 5f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(direction * m_Thrust);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

    }
    private void FixedUpdate()
    {
        Destroy(gameObject, 60f);
    }
}
