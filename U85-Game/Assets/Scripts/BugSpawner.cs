using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] BugPrefabs;
    [SerializeField] int NumOfBugPrefabs;
    [SerializeField] int NumOfInitalBugs = 10;
    [SerializeField] float SpawnerInterval = 2;
    private float initialTime;
    private static float zValue = 0;
    
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
        
        DestroyBug();
    }

    private void RandomSpawner()
    {
        GameObject bugPrefab = BugPrefabs[Random.Range(0, NumOfBugPrefabs)];
        
        // Ekran boyutlarını hard code yapabiliriz
        var newPositionX = Random.Range(-10, 10);
        var newPositionY = Random.Range(-3, 3);
        var newVector = new Vector3(newPositionX, newPositionY, zValue -= 0.0001f);
       
        LeanPool.Spawn(bugPrefab, newVector, Quaternion.identity, transform);
    }

    private void DestroyBug()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            if (hit.collider != null)
            {
                LeanPool.Despawn(hit.collider.gameObject);
            }
        }
    }
}
