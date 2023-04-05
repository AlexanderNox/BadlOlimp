using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Model
{
    public class LevelPieceFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private LevelPiece[] _levelPiecePrefabs;
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _container = diContainer;
        }
        private void OnEnable()
        {
            StartCoroutine(CreateCoroutine());
        }

        private void OnDisable()
        {
            StopCoroutine(CreateCoroutine());
        }

        private IEnumerator CreateCoroutine()
        {
            while (true)
            {
             Create();
             yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void Create()
        {
            _container.InstantiatePrefab(_levelPiecePrefabs[Random.Range(0, _levelPiecePrefabs.Length)], 
                transform.position, quaternion.identity, transform);
        }
    }
}