using System;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class SleepController : MonoBehaviour
    {
        [SerializeField] private Transform TopLid;
        [SerializeField] private Transform BottomLid;
        [SerializeField] private GameEvent LevelFailed;

        private bool _isSleep = true;
        private void Update()
        {
            if(!_isSleep)
                return;
            if(TopLid.position.y > 0 || BottomLid.position.y < 0)
            {
                TopLid.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
                BottomLid.Translate(new Vector3(0,-1,0) * Time.deltaTime);
            }
            else
            {
                _isSleep = false;
                LevelFailed.Raise();
            }
        }
    }
}