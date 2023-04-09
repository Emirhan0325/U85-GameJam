using DG.Tweening;
using UnityEngine;

public class BugScaler : MonoBehaviour
{
    [SerializeField] int scaleConst = 2;
    [SerializeField] private float scaleTime = 0.4f;
    
    public float ScaleDown ()
    {
        transform.DOScale(Vector3.zero, scaleTime)
            .SetEase(Ease.Flash);

        return scaleTime;
    }

    public void ScaleUp()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        
        Vector3 newScale = scaleConst * originalScale;
        
        transform.DOScale(newScale, scaleTime)
            .SetEase(Ease.OutBack);
    }
}
