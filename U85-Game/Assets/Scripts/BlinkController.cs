using DG.Tweening;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    [SerializeField] private Transform TopLid;
    [SerializeField] private Transform BottomLid;
    [SerializeField] private bool IsTired;
    [SerializeField] private float ScaleConst = 0.5f;
    private bool oneBlink;
    private float initialTime;
    
    public void Update()
    {
        if (IsTired)
        {
            float timer = Time.timeSinceLevelLoad - initialTime;
            if (timer < ScaleConst)
            {
                TopLid.DOMoveY(0f, ScaleConst);
                BottomLid.DOMoveY(0f, ScaleConst);
            }
            else if (timer > ScaleConst + 0.2f)
            {
                TopLid.DOMoveY(0f, ScaleConst);
                BottomLid.DOMoveY(0f, ScaleConst);

                if (timer > ScaleConst + ScaleConst + 0.3f)
                {
                    initialTime = Time.timeSinceLevelLoad;
                    IsTired = false;
                }
            }
            else if (timer > ScaleConst + 0.1f)
            {
                TopLid.DOMoveY(10f, ScaleConst);
                BottomLid.DOMoveY(-10f, ScaleConst);
            }
        }
        else
        {
            initialTime = Time.timeSinceLevelLoad;

            TopLid.DOMoveY(10f, ScaleConst);
            BottomLid.DOMoveY(-10f, ScaleConst);
        }
    }
}
