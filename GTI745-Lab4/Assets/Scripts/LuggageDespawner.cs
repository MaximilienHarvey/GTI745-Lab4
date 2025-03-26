using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Luggage"))
        {
            bool wasAllowed = other.transform.parent.parent.gameObject.GetComponent<LuggageContent>().isAllowed;
            Destroy(other.transform.parent.parent.gameObject);
            if (wasAllowed)
            {
                // Incr�menter le score
                GameManager.Instance.AddLuggageWithoutContrabandScore();
            }
            else
            {
                // Enlever une vie
                GameManager.Instance.LoseLife();
            }
        }
    }
}
