using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block BlockPrefab;
    [SerializeField] private BlockProperties[] _blockProperties;


    
    
    private void Start()
    {
        _blockProperties = BlockPropertiesData.Instance.GetBlockProperties();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBlockFromBlockPropertiesRandomly();
        }
            
    }

    private void SpawnBlockFromBlockPropertiesRandomly()
    {
        int randomIndex = UnityEngine.Random.Range(0, 2);
        Block block = Instantiate(BlockPrefab, transform.position, Quaternion.identity);
        block.SetBlockProperties(_blockProperties[randomIndex]);
        block.SetCurrentBlockPropertiesIndex(randomIndex);
    }
    
}