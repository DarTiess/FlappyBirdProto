﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay
{
    public class BlocksSpawner: MonoBehaviour
    {
        [SerializeField] private List<Blocks> _blocksPrefab;
        [SerializeField] private int _countBlocksPool;

        private List<Blocks> _blocksList;
        private int _countBlocks;
        public void CreateBlocks(Vector3 position, Transform parent, int countBlocks)
        {
            _blocksList = new List<Blocks>(_countBlocksPool);
            _countBlocks = countBlocks;

            for (int i = 0; i < _countBlocksPool; i++)
            {
                int rndBlock = Random.Range(0, _blocksPrefab.Count);
                Vector3 newPosition = position + new Vector3(i-3f, 0f, 0f);
                Blocks block=  Instantiate(_blocksPrefab[rndBlock], newPosition, Quaternion.identity);
                block.Init(parent);
                block.Hide();
                _blocksList.Add(block);
            }
        }

        public void ChangeBlocksCountOnScene(int count)
        {
            _countBlocks = count;
        }
        public void SetBlocks()
        {
            foreach (Blocks blocks in _blocksList)
            {
                blocks.Hide();
            }

            for (int i = 0; i < _countBlocks; i++)
            {
                int rndIndex = Random.Range(0, _blocksList.Count);
                _blocksList[rndIndex].Show();
            }
           
        }
    }
}