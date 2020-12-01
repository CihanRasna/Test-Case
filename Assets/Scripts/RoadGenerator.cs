using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] roadPrefabs;
    [SerializeField] private List<GameObject> activeRoads = new List<GameObject>();

    [SerializeField] private float spawnPos;
    [SerializeField] private float minSpawnRange = 1f;
    [SerializeField] private float maxSpawnRange = 5f;

    private float spawnRange = 1f;
    private Transform playerTransform;

    private Quaternion randomRotation;

    void Start()
    {
        for (var i = 0; i < 5; i++)
        {
             SpawnRoad(0);
        }
        playerTransform = GameObject.Find("Player").transform;
        spawnRange = Random.Range(minSpawnRange, maxSpawnRange);
    }

    void Update()
    {
        if (!(playerTransform.position.z > spawnRange + activeRoads[0].transform.position.z )  ) return;
        SpawnRoad(0);
        DeleteRoad();
    }

    void SpawnRoad(int roadIndex)
    {
        randomRotation = Quaternion.Euler(0, 0, Random.Range(-75, 75));
        var go = Instantiate(roadPrefabs[roadIndex], transform.forward * spawnPos, randomRotation);
        activeRoads.Add(go);
        spawnRange = Random.Range(minSpawnRange, maxSpawnRange);
        spawnPos += spawnRange;
    }

    void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}