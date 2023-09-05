using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay
{
    public class ObjectsPool: MonoBehaviour
    {
        [SerializeField] protected Transform _container;
        [SerializeField] private int _capacity;

        private Camera _camera;
        private List<Blocks> _pool = new List<Blocks>();

        protected void Init(List<Blocks> _prefabs)
        {
            _camera = Camera.main;
            for (int i = 0; i < _capacity; i++)
            {
                int rndBlock = Random.Range(0, _prefabs.Count);
                Blocks spawned = Instantiate(_prefabs[rndBlock], _container);
                spawned.Hide();
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out Blocks result)
        {
            result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
            return result != null;
        }
        
    }
}