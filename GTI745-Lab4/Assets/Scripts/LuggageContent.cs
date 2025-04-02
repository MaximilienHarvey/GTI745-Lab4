using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageContent : MonoBehaviour
{
    [SerializeField] private GameObject ContentParent;
    [SerializeField] private GameObject[] allowedItems;
    [SerializeField] private GameObject[] forbiddenItems;
    [SerializeField] private float probabilityOfForbiddenItem = 0.5f;
    [SerializeField] private int numberOfItemsInside = 1;
    [SerializeField] private float timeBeforeOneMoreItem = 60.0f;
    public bool isAllowed = true;
    public bool hasBeenTriggered = false;

    private void Start()
    {
        int itemsLeftToSpawn = numberOfItemsInside + Mathf.FloorToInt(Time.time / timeBeforeOneMoreItem);
        if (Random.value < probabilityOfForbiddenItem)
        {
            SpawnItem(false);
            isAllowed = false;
            itemsLeftToSpawn--;
        }
        while (itemsLeftToSpawn > 0)
        {
            SpawnItem(true);
            itemsLeftToSpawn--;
        }
    }

    private void SpawnItem(bool allowed)
    {
        GameObject itemToSpawn = null;
        if (allowed)
        {
            itemToSpawn = allowedItems[Random.Range(0, allowedItems.Length)];
        }
        else
        {
            itemToSpawn = forbiddenItems[Random.Range(0, forbiddenItems.Length)];
        }

        // Maybe spawn at a random position within the luggage
        Instantiate(itemToSpawn, transform.position, Quaternion.identity, ContentParent.transform);
    }
}
