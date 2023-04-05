using System;
using UnityEngine;
using Zenject;

namespace Model
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _moveUpFactor;
        [SerializeField] private bool _active;
        private InputMap _inputMap;
        private Rigidbody2D _rigidbody2D;

        [Inject]
        private void Construct(InputMap inputMap)
        {
            _inputMap = inputMap;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_active)
            {
                if (_inputMap.Map.UP.IsPressed() )
                {
                    MoveUp();      
                }
            }
            
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out Character character))
            {
                character.WakeUp(_inputMap);
            }
        }

        private void WakeUp(InputMap inputMap)
        {
            _inputMap = inputMap;
            _active = true;
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }

        private void MoveUp()
        {
            Debug.Log("MoveUp");
            _rigidbody2D.AddForce(Vector2.up * _moveUpFactor, ForceMode2D.Force);
        }
    }
}