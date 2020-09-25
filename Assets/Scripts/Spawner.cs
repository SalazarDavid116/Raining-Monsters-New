using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //instance field
    public Transform[] SpawnPoints;
    public GameObject[] Monsters;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBtwSpawns;
    public float decrease;

    public GameObject player;
    
    // ---------------------------------------------------------
    // Added functions
    
    
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
                //Spawn monsters
                Transform randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                GameObject randomMonster = Monsters[Random.Range(0, Monsters.Length)];

                Instantiate(randomMonster, randomSpawnPoint.position, Quaternion.identity);

                if (startTimeBtwSpawns > minTimeBtwSpawns)  {
                    startTimeBtwSpawns -= decrease;
                }

                timeBtwSpawns = startTimeBtwSpawns;
            } else {
                timeBtwSpawns -= Time.deltaTime;
            } // if (timeBtwSpawns <= 0) / Else 
        } // if (player != null)
    } // function - Update()
}
