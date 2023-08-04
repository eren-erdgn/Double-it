using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Block BlockPrefab;
    public BlockProperties[] BlockProperties;

    private int _topNumber;
    private BlockProperties _blockProperty;
    private Block lastSpawnedBlock;

    private void OnEnable()
    {
        Events.onTopNumberChanged.AddListener(OnTopNumberChanged);
    }

    private void OnDisable()
    {
        Events.onTopNumberChanged.RemoveListener(OnTopNumberChanged);
    }
    
    private void Start()
    {
        _blockProperty = BlockProperties[0];
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyLastSpawnedBlock();
            ChangeBlockProperties(_topNumber);
            SpawnBlock();
        }
    }

    private void ChangeBlockProperties(int topNumber)
    {
        
        if (topNumber >= 2048)
        {
            int randomIndex = UnityEngine.Random.Range(0, 6);
            _blockProperty = BlockProperties[randomIndex];
        }
        else if (topNumber >= 1024)
        {
            int randomIndex = UnityEngine.Random.Range(0, 5);
            _blockProperty = BlockProperties[randomIndex];
        }
        else if (topNumber >= 512)
        {
            int randomIndex = UnityEngine.Random.Range(0, 4);
            _blockProperty = BlockProperties[randomIndex];
        }
        else if (topNumber >= 64)
        {
            int randomIndex = UnityEngine.Random.Range(0, 3);
            _blockProperty = BlockProperties[randomIndex];
        }
        else
        {
            int randomIndex = UnityEngine.Random.Range(0, 2);
            _blockProperty = BlockProperties[randomIndex];
        }
    }

    private void SpawnBlock()
    {
        lastSpawnedBlock = Instantiate(BlockPrefab, transform.position, Quaternion.identity);
        lastSpawnedBlock.SetBlockProperties(_blockProperty);
    }

    private void DestroyLastSpawnedBlock()
    {
        if (lastSpawnedBlock != null)
        {
            Destroy(lastSpawnedBlock.gameObject);
        }
    }
    

    private void OnTopNumberChanged(int topNumber)
    {
        Debug.Log("OnTopNumberChanged: " + topNumber);
        _topNumber = topNumber;
    }
}