using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 0.25f;
    [SerializeField] private float acceleration = 1.005f;
    private float velocity;

    public void Start()
    {
        velocity = initialVelocity;
    }

    public void Update()
    {
        velocity *= acceleration;
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.rigidbody != null)
        {
            Vector3 movement = velocity * transform.right * Time.deltaTime;
            other.rigidbody.MovePosition(other.transform.position + movement);
        }
    }
}
