using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CubeSurfer
{
    public class CubesContainer : MonoBehaviour
    {
        public static CubesContainer Instance { get; private set; }

        public event Action OnListEmpty;

        [SerializeField] private Transform _cubeTemplate;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private CollectorCube _collectorCube;

        private List<Transform> _transformCubes;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _transformCubes = new List<Transform>();
            SpawnCubes();
        }

        private void OnEnable()
        {
            _collectorCube.OnAddedCube += SpawnCubes;
        }

        private void OnDisable()
        {
            _collectorCube.OnAddedCube -= SpawnCubes;
        }

        private void SpawnCubes()
        {
            Transform newCube = Instantiate(_cubeTemplate);
            newCube.SetParent(_spawnPosition);
            newCube.transform.localPosition = SpawnLocalPosition();
            _transformCubes.Add(newCube);
        }

        private Vector3 SpawnLocalPosition()
        {
            return new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
        }

        public void RemovedList(Transform cube)
        {
            _transformCubes.Remove(cube);

            if (_transformCubes.Count == 0)
            {
                OnListEmpty?.Invoke();
            }
        }
    }
}

