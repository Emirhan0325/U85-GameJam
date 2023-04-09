using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Lean.Pool;
using UnityEngine.Serialization;

public class TeraziController : MonoBehaviour
{

    public GameObject pivot;
    public bool _Isleft;
    public bool _Isright;
    
    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     col.TryGetComponent(out BallEmpty _Ball);
    //     if (_Ball)
    //     {
    //         if (_Isleft)
    //         {
    //             Debug.Log("ss");
    //             pivot.transform.DORotate(pivot.transform.localRotation.eulerAngles + new Vector3(0, 0, 100), 0f);
    //         }
    //         else
    //         {
    //             Debug.Log("aa"); 
    //             pivot.transform.DORotate(pivot.transform.localRotation.eulerAngles + new Vector3(0, 0, -100), 0f);
    //         }
    //         LeanPool.Despawn(_Ball.gameObject);
    //         // Quaternion rot = transform.rotation;
    //         //
    //         // float z = Mathf.Clamp(rot.eulerAngles.z, -120, 120);
    //     }

    // }
}
