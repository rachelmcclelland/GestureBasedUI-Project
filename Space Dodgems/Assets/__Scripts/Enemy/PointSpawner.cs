using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

// used for the first enemy

//spawn enemies at different spawn points
public class PointSpawner : MonoBehaviour
{
    // field attributes
    [SerializeField]
    private Enemy enemyPrefab;
    private float spawnDelay = 0.5f;
    private float spawnInterval = 1.0f;

    private IList<SpawnPoint> spawnPoints;

    private Stack<SpawnPoint> spawnStack;

    private GameObject enemyParent;

    void Start()
    {
        // get the enemey parent object
        enemyParent = ParentUtils.GetEnemyParent();
        // need to get a list of spawn points
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnRepeating();
    }

    // invokeRepeating 
    private void SpawnRepeating()
    {
        // create the stack
        // create the method in a Utils class
        spawnStack = ListUtils.CreateShuffleStack(spawnPoints);
        InvokeRepeating("Spawn", spawnDelay, spawnInterval);
    }

    // spawn a single enemy ship
    private void Spawn()
    {
        if (spawnStack.Count == 0)
        {
            // reshuffle the stack again
            spawnStack = ListUtils.CreateShuffleStack(spawnPoints);
        }
        var spawnPoint = spawnStack.Pop();

        //var enemy = Instantiate(enemyPrefab); //adds to the hierachy base level
        var enemy = Instantiate(enemyPrefab, enemyParent.transform);
        enemy.transform.position = spawnPoint.transform.position;
    }
}
