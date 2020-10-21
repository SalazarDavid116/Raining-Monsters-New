using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerCloud : MonoBehaviour
{
    public Transform[] spawnPointerCloudSmall;
    public Transform[] spawnPointerCloudMedium;
    public Transform[] spawnPointerCloudLarge;
    
    public GameObject[] cloudSmall;
    public GameObject[] cloudMedium;
    public GameObject[] cloudLarge;

    private float timeBtwSpawns;
    //public float startTimeBtwSpawns;

    public GameObject player;

    // ---------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
        
    } // function - Start()

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            if (timeBtwSpawns <= 0) {
                Transform randomSpawnPoint1 = spawnPointerCloudSmall[Random.Range(0, spawnPointerCloudSmall.Length)];
                Transform randomSpawnPoint2 = spawnPointerCloudMedium[Random.Range(0, spawnPointerCloudMedium.Length)];
                Transform randomSpawnPoint3 = spawnPointerCloudLarge[Random.Range(0, spawnPointerCloudLarge.Length)];
                
                GameObject randomCloudyS = cloudSmall[Random.Range(0, cloudSmall.Length)];
                GameObject randomCloudyM = cloudMedium[Random.Range(0, cloudMedium.Length)];
                GameObject randomCloudyL = cloudLarge[Random.Range(0, cloudLarge.Length)];

                Instantiate(randomCloudyS, randomSpawnPoint1.position, quaternion.identity);
                Instantiate(randomCloudyM, randomSpawnPoint2.position, quaternion.identity);
                Instantiate(randomCloudyL, randomSpawnPoint3.position, quaternion.identity);
                
                timeBtwSpawns = Random.Range(2, 10);
            } else {
                timeBtwSpawns -= Time.deltaTime; 
            } // if (timeBtwSpawns <= 0) / Else
            
        } // if (player != null)
    } // function - Update()
}
