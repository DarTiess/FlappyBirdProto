using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class BlocksGenerator: ObjectsPool
    {
        [SerializeField] private List<Blocks> _blocksPrefabs;
        [SerializeField] private float _secondsBetweenSpawn;

        private float _timer;

        private void Start()
        {
            Init(_blocksPrefabs);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _secondsBetweenSpawn)
            {
                if (TryGetObject(out Blocks block))
                {
                  
                   block.Show();
                   Debug.Log("Show");
                   block.transform.position = _container.position;
                   _timer = 0;
                }
            }
        }
    }
}