using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{

    [SerializeField] private float _width;
    [SerializeField] private int _height;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _boardParent;
    [SerializeField] private Transform _choosingBoardParent;
    [SerializeField] private List<Transform> choosingTileTransforms = new();
    [SerializeField] private List<List<Transform>> tileTransforms = new();

    public List<Transform> GetChoosingTileTransforms { get => choosingTileTransforms; }
    public List<List<Transform>> GetTileTransforms { get => tileTransforms; }


    public static BoardSpawner Instance;
    private void Awake() {
        Instance = this;
        GenerateBoard();
        GenerateChoosingBoard();
    }

    
    
    void GenerateChoosingBoard()
    {
        for (float x = -_width + 1; x < _width; x++)
        {
            _tilePrefab.transform.localScale = new Vector3(1f, 1f, 1f);
            GameObject newChoosingTile = Instantiate(_tilePrefab, new Vector2(x, 0), Quaternion.identity,_choosingBoardParent);
            choosingTileTransforms.Add(newChoosingTile.transform);
        }
    }
    void GenerateBoard()
    {
        for (float x = -_width + 1; x < _width; x++)
        {
            GenerateList();
            for (float y = 1; y < _height; y++)
            {   
                _tilePrefab.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                GameObject newTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity,_boardParent);
                tileTransforms[^1].Add(newTile.transform);
            }
        }
    }

    void GenerateList()
    {
        
        List<Transform> newList = new();
        tileTransforms.Add(newList);
    }
}
