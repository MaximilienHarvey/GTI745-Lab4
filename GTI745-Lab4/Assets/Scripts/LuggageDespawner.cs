using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageDespawner : MonoBehaviour
{
    [SerializeField] private bool wantsGoodLuggage = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Luggage"))
        {
            bool wasAllowed = other.transform.parent.parent.gameObject.GetComponent<LuggageContent>().isAllowed;
            Destroy(other.transform.parent.parent.gameObject);
            if (wasAllowed)
            {
                if (wantsGoodLuggage)
                {
                    // Incr�menter le score
                }
                else
                {
                    // D�cr�menter le score
                }
            }
            else
            {
                if (wantsGoodLuggage)
                {
                    // Enlever une vie
                }
                else
                {
                    // Incr�menter le score
                }

            }
        }
    }
}
