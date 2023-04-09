using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace ProjectManagement
{
    public class PostItController : MonoBehaviour
    {
        [SerializeField] private List<Material> Colors;
        [SerializeField] private SpriteRenderer Sprite;
        [SerializeField] private List<TransformRef> Areas;
        [SerializeField] private IntRef KanbanGameValue;

        private int _currentSprite;
        private int _nextSprite;
        private int _nextArea;
        private bool _isClickable = true;
        
        private void Start()
        {
            SetSprite(Random.Range(0, Colors.Count-1));//get random
        }

        private void SetSprite(int index)
        {
            _currentSprite = index; 
            _nextSprite = _currentSprite + 1;
            Sprite.material.color = Colors[_currentSprite].color;
            _nextArea = index;
        }

        public void OnClick()
        {
            if (!_isClickable)
                return;
            _isClickable = false;
            if (_nextArea < Areas.Count)
            {
                transform.parent = Areas[_nextArea].Value;
                
                transform.DOLocalJump(Vector3.zero + new Vector3(Random.Range(-.3f, .3f), Random.Range(-.1f,.1f)), .25f, 1, .5f).OnComplete(() =>
                {
                    SetSprite(_nextSprite);
                    _isClickable = true;
                });
                
            }
            else
            {
                KanbanGameValue.Value++;
                transform.DOScale(Vector3.zero, .5f).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            }
            
        }
    }
}
