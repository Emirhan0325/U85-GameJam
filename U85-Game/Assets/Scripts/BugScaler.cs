using DG.Tweening;
using UnityEngine;

public class BugScaler : MonoBehaviour
{
    [SerializeField] int scaleConst = 2;
    [SerializeField] private float scaleTime = 0.3f;
    
    void Start()
    {
        Vector2 originalScale = transform.localScale;
        transform.localScale = new Vector3(0.2f, 0.2f, 1);
        
        Vector2 newScale = scaleConst * originalScale;
        
        transform.DOScale(newScale, scaleTime)
            .SetEase(Ease.Flash);
    }
    
    public float ScaleDown ()
    {
        Vector2 newScale = new Vector3(0.2f, 0.2f, 1);
        
        transform.DOScale(newScale, scaleTime)
            .SetEase(Ease.Flash);

        return scaleTime;
    }
}
