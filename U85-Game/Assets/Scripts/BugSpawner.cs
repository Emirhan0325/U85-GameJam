using System;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] BugPrefabs;
    [SerializeField] int NumOfBugPrefabs;
    [SerializeField] int NumOfInitalBugs = 3;
    [SerializeField] float SpawnerInterval = 3;
    private float initialTime;
    
    void Start()
    {
        initialTime = Time.timeSinceLevelLoad;
        
        for (int i = 0; i < NumOfInitalBugs; i++)
        {
            RandomSpawner();            
        }
    }

    private void Update()
    {
        float timer = Time.timeSinceLevelLoad - initialTime;

        if (timer > SpawnerInterval)
        {
            initialTime = Time.timeSinceLevelLoad;
            RandomSpawner();
        }
    }

    private void RandomSpawner()
    {
        GameObject bugPrefab = BugPrefabs[Random.Range(0, NumOfBugPrefabs)];
        
        // Ekran boyutlarını hard code yapabiliriz
        var newPositionX = Random.Range(-10, 10);
        var newPositionY = Random.Range(-3, 3);
        var newVector = new Vector2(newPositionX, newPositionY);
       
        LeanPool.Spawn(bugPrefab, newVector, Quaternion.identity, transform);
    }
}
