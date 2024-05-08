using System;
using UnityEngine;

namespace ChuongCustom
{
    public class Knife : Singleton<Knife>
    {
        public SpriteRenderer _skin;

        public void Flip()
        {
            rb.freezeRotation = false;
        }
        
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            _skin.sprite = SkinDataManager.Instance.CurrentSkin;

            Gravity = _max;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MinusGravity();
            }
            else
            {
                AddGravity();
            }
        }

        private float _gravity;

        public float Gravity
        {
            get => _gravity;
            set
            {
                _gravity = value;
                rb.gravityScale = _gravity;
            }
        }

        public float _deltaPoint = 0.03f;
        public float _deltaPoint1 = 0.03f;
        public float _min, _max;

        private void AddGravity()
        {
            if (Gravity < _max)
                Gravity += _deltaPoint;
        }

        private void MinusGravity()
        {
            if (Gravity > _min)
                Gravity -= _deltaPoint1;
        }
    }
}