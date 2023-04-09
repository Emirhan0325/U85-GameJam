using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ProjectManagement
{
    public class KanbanBoardController : MonoBehaviour
    {
        [SerializeField] private List<TransformRef> AreaRefs;
        [SerializeField] private List<Transform> AreaTransforms;

        private void Awake()
        {
            for (int i = 0; i < AreaRefs.Count; i++)
            {
                AreaRefs[i].Value = AreaTransforms[i];
            }
        }
    }
}
