using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageDespawner : MonoBehaviour
{
    [SerializeField] private bool wantsGoodLuggage = true;

    [SerializeField] private AudioClip loseLifeSound;
    [SerializeField] private AudioClip wrongLuggageSound;
    [SerializeField] private AudioClip correctLuggageSound;
    
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
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
                    audioSource.PlayOneShot(wrongLuggageSound);
                }
            }
            else
            {
                if (wantsGoodLuggage)
                {
                    // Enlever une vie
                    GameManager.Instance.LoseLife();
                    audioSource.PlayOneShot(loseLifeSound);
                }
                else
                {
                    // Incrémenter le score
                    GameManager.Instance.AddLuggageWithContrabandScore();
                    audioSource.PlayOneShot(correctLuggageSound);
                }
            }
        }
    }
}
