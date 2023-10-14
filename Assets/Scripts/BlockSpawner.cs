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

        DetectNumbersFromKeyboard();

            
    }

    private void SpawnBlockFromBlockProperties(int index)
    {
        Block block = Instantiate(BlockPrefab, transform.position, Quaternion.identity);
        block.SetBlockProperties(_blockProperties[index]);
        block.SetCurrentBlockPropertiesIndex(index);
    }

    
    private void DetectNumbersFromKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnBlockFromBlockProperties(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnBlockFromBlockProperties(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnBlockFromBlockProperties(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnBlockFromBlockProperties(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SpawnBlockFromBlockProperties(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SpawnBlockFromBlockProperties(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SpawnBlockFromBlockProperties(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SpawnBlockFromBlockProperties(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SpawnBlockFromBlockProperties(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpawnBlockFromBlockProperties(9);
        }
    }
    
}