using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class BlocksSpawner: MonoBehaviour
    {
        [SerializeField] private List<Blocks> blocksPrefab;

        private List<Blocks> _blocksList;
        public void CreateBlocks(Vector3 position, Transform parent)
        {
            _blocksList = new List<Blocks>(blocksPrefab.Count);
            foreach (Blocks blocks in blocksPrefab)
            {
                Blocks block=  Instantiate(blocks, position, Quaternion.identity);
                block.Init(parent);
                block.Hide();
                _blocksList.Add(block);
            }
           
        }

        public void SetBlocks()
        {
            foreach (Blocks blocks in _blocksList)
            {
                blocks.Hide();
            }
            int rndIndex = Random.Range(0, _blocksList.Count);
            _blocksList[rndIndex].Show();
        }
    }
}