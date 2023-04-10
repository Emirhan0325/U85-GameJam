using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using Utils;

public class BalanceCounter : MonoBehaviour
{
    [SerializeField] private FloatRef LawGame;
    [SerializeField] private FloatRef BlinkCounter;
    [SerializeField] private Transform _TeraziTransform;
    [SerializeField] private float IncreaseAmount = 0.1f;

    private void Update()
    {
         var a = _TeraziTransform.rotation;
        
        if(a == Quaternion.identity)
        {
            BlinkCounter.Value++;
            LawGame.Value += IncreaseAmount;
        }
        
    }
}
