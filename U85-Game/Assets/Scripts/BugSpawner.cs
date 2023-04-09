using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using Utils.RefValue;
using Random = UnityEngine.Random;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] bugPrefabs;
    [SerializeField] int numOfBugPrefabs;
    [SerializeField] int numOfInitialBugs = 10;
    [SerializeField] float spawnerInterval = 0.6f;
    [SerializeField] IntRef numOfDeadBugs;
    private float initialTime;
    private static float zValue;
    
    void Start()
    {
        if (numOfDeadBugs != null)
        {
            numOfDeadBugs.Value = 0;
        }
        
        initialTime = Time.timeSinceLevelLoad;
        
        for (int i = 0; i < numOfInitialBugs; i++)
        {
            RandomSpawner();            
        }
    }

    void Update()
    {
        float timer = Time.timeSinceLevelLoad - initialTime;

        if (timer > spawnerInterval)
        {
            initialTime = Time.timeSinceLevelLoad;
            RandomSpawner();
        }
        
        DestroyBug();
    }

    void RandomSpawner()
    {
        GameObject bugPrefab = bugPrefabs[Random.Range(0, numOfBugPrefabs)];
        
        // Ekran boyutlarını hard code yapabiliriz
        var newPositionX = Random.Range(-10, 10);
        var newPositionY = Random.Range(-3, 3);
        var newVector = new Vector3(newPositionX, newPositionY, zValue -= 0.0001f);
       
        var bug= LeanPool.Spawn(bugPrefab, newVector, Quaternion.identity, transform);
        
        bug.GetComponent<BugScaler>().ScaleUp();
    }

    void DestroyBug()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            if (hit.collider != null)
            {
                float scaleTime = hit.collider.gameObject.GetComponent<BugScaler>().ScaleDown();

                DOVirtual.DelayedCall(scaleTime + 0.001f, () => { LeanPool.Despawn(hit.collider.gameObject); });

                if (numOfDeadBugs != null)
                {
                    numOfDeadBugs.Value++;
                }
            }
        }
    }
}
