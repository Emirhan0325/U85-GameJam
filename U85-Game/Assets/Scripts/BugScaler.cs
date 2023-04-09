using DG.Tweening;
using UnityEngine;

public class BugScaler : MonoBehaviour
{
    public float ScaleDown (float scaleTime)
    {
        transform.DOScale(Vector3.zero, scaleTime)
            .SetEase(Ease.Flash);

        return scaleTime;
    }

    public void ScaleUp(float scaleTime, float scaleConst)
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        
        Vector3 newScale = scaleConst * originalScale;
        
        transform.DOScale(newScale, scaleTime)
            .SetEase(Ease.OutBack);
    }
}
