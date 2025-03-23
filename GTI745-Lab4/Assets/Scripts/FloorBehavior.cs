using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public Transform respawnPos;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Luggage"))
        {
            collision.transform.position = respawnPos.position;
            collision.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            foreach (Rigidbody rb in collision.transform.gameObject.GetComponentsInChildren<Rigidbody>())
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
