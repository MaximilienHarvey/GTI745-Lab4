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
            LuggageContent luggageContent = other.transform.parent.parent.gameObject.GetComponent<LuggageContent>();
            if(luggageContent.hasBeenTriggered)
                return;
            
            Debug.Log(other.name);
            bool wasAllowed = luggageContent.isAllowed;
            luggageContent.hasBeenTriggered = true;
            Destroy(other.transform.parent.parent.gameObject);
            if (wasAllowed)
            {
                
                if (wantsGoodLuggage)
                {
                    // Incrémenter le score
                    GameManager.Instance.AddLuggageWithoutContrabandScore();
                }
                else
                {
                    // Décrémenter le score
                    GameManager.Instance.RemoveBadLuggageScore();
                }
            }
            else
            {
                if (wantsGoodLuggage)
                {
                    // Enlever une vie
                    GameManager.Instance.LoseLife();
                }
                else
                {
                    // Incrémenter le score
                    GameManager.Instance.AddLuggageWithContrabandScore();
                }
            }
        }
    }
}
