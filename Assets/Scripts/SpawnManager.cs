using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] animalPrefabsSideways;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnRangeZ = 20;
    private float spawnPosX = 30;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {   
        // note: animals spawn off screen; solution is either lessen spawnrange or zoom out camera
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnAnimalsLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnAnimalsRight", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Randomly generates animal index and spawn position
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnAnimalsLeft()
    {
        Vector3 spawnPosLeft = new Vector3(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            int animalIndexSideways = Random.Range(0, animalPrefabsSideways.Length);
            Instantiate(animalPrefabsSideways[animalIndexSideways], spawnPosLeft, Quaternion.Euler(0, 270, 0));
    }

    void SpawnAnimalsRight()
    {
        Vector3 spawnPosRight = new Vector3(-spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            int animalIndexSideways = Random.Range(0, animalPrefabsSideways.Length);
            Instantiate(animalPrefabsSideways[animalIndexSideways], spawnPosRight, Quaternion.Euler(0, 90, 0));
    }
}
