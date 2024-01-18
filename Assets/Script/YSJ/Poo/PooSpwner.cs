using System.Collections;
using UnityEngine;

public class PooSpwner : MonoBehaviour
{
    public GameObject[] pooPrefabs;
    public float spawnProbability = 0.5f;
    public float spawnInterval = 1f;
    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if(Random.value < spawnProbability)
        {
            GameObject selectedPooPrefab = pooPrefabs[Random.Range(0, pooPrefabs.Length)];
            Vector2 spawnPosition = new Vector2(Random.Range(-3f, 3f), 7f);
            Instantiate(selectedPooPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
