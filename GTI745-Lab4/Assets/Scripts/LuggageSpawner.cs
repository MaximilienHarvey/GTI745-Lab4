using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject luggagePrefab;
    [SerializeField] private float initialSpawnRate = 0.2f;
    [SerializeField] private float acceleration = 1.005f;
    private float spawnRate;

    public void Start()
    {
        spawnRate = initialSpawnRate;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1/spawnRate);
        Instantiate(luggagePrefab, transform.position, Quaternion.identity);
        spawnRate *= acceleration;
        StartCoroutine(SpawnCoroutine());
    }
}
