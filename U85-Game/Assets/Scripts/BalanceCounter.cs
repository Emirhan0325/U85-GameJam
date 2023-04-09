using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class BalanceCounter : MonoBehaviour
{
    //[SerializeField] TMP_Text _text;
    private float _BalanceSituation;
    [SerializeField] private Transform _TeraziTransform;
    

    public float fillSpeed;
    public Slider _slider;

    public Gradient _gradient;

    

    private void Start()
    {
        _BalanceSituation = fillSpeed;
        _slider.value = _BalanceSituation;
    }

    private void Update()
    {
         var a = _TeraziTransform.rotation;
        
        if(a == Quaternion.identity)
        {
            _BalanceSituation++;
            //_text.text = _BalanceSituation.ToString();
            _slider.value = _BalanceSituation;
            _slider.fillRect.GetComponentInChildren<Image>().color = _gradient.Evaluate(_BalanceSituation/_slider.maxValue);
        }
        
    }
}
