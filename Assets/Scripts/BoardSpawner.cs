using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardSpawner : MonoBehaviour
{

    [SerializeField] private float width;
    [SerializeField] private int height;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform boardParent;
    [SerializeField] private Transform choosingBoardParent;
    [SerializeField] private List<Transform> choosingTileTransforms = new();
    private readonly List<List<Transform>> _tileTransforms = new();

    public List<Transform> GetChoosingTileTransforms => choosingTileTransforms;
    public List<List<Transform>> GetTileTransforms => _tileTransforms;


    public static BoardSpawner Instance;
    private void Awake() {
        Instance = this;
        GenerateBoard();
        GenerateChoosingBoard();
    }

    
    
    void GenerateChoosingBoard()
    {
        for (float x = -width + 1; x < width; x++)
        {
            tilePrefab.transform.localScale = new Vector3(1f, 1f, 1f);
            GameObject newChoosingTile = Instantiate(tilePrefab, new Vector2(x, 0), Quaternion.identity,choosingBoardParent);
            choosingTileTransforms.Add(newChoosingTile.transform);
        }
    }
    void GenerateBoard()
    {
        for (float x = -width + 1; x < width; x++)
        {
            GenerateList();
            for (float y = 1; y < height; y++)
            {   
                tilePrefab.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                GameObject newTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity,boardParent);
                _tileTransforms[^1].Add(newTile.transform);
            }
        }
    }

    void GenerateList()
    {
        
        List<Transform> newList = new();
        _tileTransforms.Add(newList);
    }
}
