using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] bugPrefabs;
    [SerializeField] int numOfBugPrefabs;
    [SerializeField] int numOfInitialBugs = 10;
    [SerializeField] float spawnerInterval = 0.6f;
    [SerializeField] IntRef numOfDeadBugs;
    [SerializeField] float scaleConst = 2f;
    [SerializeField] float scaleTime = 0.4f;
    [SerializeField] float UISize = 1f;
    private float initialTime;
    private static float zValue;
    private float[] screenBorders = {0, 0, 0, 0};
    
    void Start()
    {
        screenBorders[0] = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x; // leftX
        screenBorders[1] = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x; // rightY
        screenBorders[2]= Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).y; // upY
        screenBorders[3] = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y; // downY

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
        
        var w = bugPrefab.GetComponent<SpriteRenderer>().bounds.size.x / 2 * scaleConst;
        var h = bugPrefab.GetComponent<SpriteRenderer>().bounds.size.y / 2 * scaleConst;
        
        var newPositionX = Random.Range(screenBorders[0] + w, screenBorders[1] - w);
        var newPositionY = Random.Range(screenBorders[2] + h, screenBorders[3] - h - UISize);
        var newVector = new Vector3(newPositionX, newPositionY, zValue -= 0.0001f);
       
        var bug= LeanPool.Spawn(bugPrefab, newVector, Quaternion.identity, transform);
        
        bug.GetComponent<BugScaler>().ScaleUp(scaleTime, scaleConst);
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
                float scaleTime = hit.collider.gameObject.GetComponent<BugScaler>().ScaleDown(this.scaleTime);

                DOVirtual.DelayedCall(scaleTime + 0.001f, () => { LeanPool.Despawn(hit.collider.gameObject); });

                if (numOfDeadBugs != null)
                {
                    numOfDeadBugs.Value++;
                }
            }
        }
    }
}
