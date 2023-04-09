using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using Utils.RefValue;


public class PlatformController : MonoBehaviour
{

    
    public GameObject pivot;

    [SerializeField] private bool _Isleft;

    private bool _canRotate = true;

    private float currentRotation;
    private float deltaRotationLeft;
    private float deltaRotationRight;

    private void Awake()
    {
        currentRotation = pivot.transform.localRotation.eulerAngles.z;
        deltaRotationLeft = Mathf.DeltaAngle(currentRotation, 30f);
        deltaRotationRight = Mathf.DeltaAngle(currentRotation, -30f);
    }

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.TryGetComponent(out BallEmpty _Ball);
        if (_Ball)
        {
            if (_Isleft)
            {
                const float maxRotation = 30f;
                const float minRotation = -60f;

                currentRotation = pivot.transform.localRotation.eulerAngles.z;
                // float deltaRotation = Mathf.DeltaAngle(currentRotation, maxRotation);

                if (deltaRotationLeft > -30f)
                {
                    float rotationAmount = Mathf.Min(-deltaRotationLeft, 10f);
                    float newRotation = Mathf.Clamp(currentRotation + 10f, minRotation, maxRotation);
                    pivot.transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
                }

                Debug.Log("ss");
            }
            else
            {
                const float maxRotation = 0f;
                const float minRotation = -30f;

                currentRotation = pivot.transform.localRotation.eulerAngles.z;
                // float deltaRotation = Mathf.DeltaAngle(currentRotation, minRotation);

                if (deltaRotationRight < 30f)
                {
                    float rotationAmount = Mathf.Min(deltaRotationRight, -10f);
                    // float rotationAmount = Mathf.Min(-deltaRotation, 10f);
                    float newRotation = Mathf.Clamp(currentRotation - 10f, minRotation, maxRotation);
                    
                    
                    // if (newRotation <= minRotation) // MinRotation'a ulaşıldığında dönüş yönünü tersine çevir
                    // {
                    //     var f = 10f;
                    //     f *= -1f;
                    // }
                    pivot.transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
                }

                Debug.Log("aa");
            }

            LeanPool.Despawn(_Ball.gameObject);
        }
    }
}



