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
    [SerializeField] private List<Transform> choosingTileTransforms = new List<Transform>();
    [SerializeField] private List<List<Transform>> tileTransforms = new List<List<Transform>>();

    public List<Transform> getChoosingTileTransforms { get => choosingTileTransforms; }
    public List<List<Transform>> getTileTransforms { get => tileTransforms; }

    public static BoardSpawner Instance;
    private void Awake() {
        Instance = this;
        GenerateBoard();
        generateChoosingBoard();
    }

    
    
    void generateChoosingBoard()
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
            generateList();
            for (float y = 1; y < _height; y++)
            {   
                _tilePrefab.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                GameObject newTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity,_boardParent);
                tileTransforms[tileTransforms.Count - 1].Add(newTile.transform);
            }
        }
    }

    private void generateList()
    {
        
        List<Transform> newList = new List<Transform>();
        tileTransforms.Add(newList);
    }
    void showListOfList()
    {
        for (int i = 0; i < tileTransforms.Count; i++)
        {
            Debug.Log("--------------------");
            for (int j = 0; j < tileTransforms[i].Count; j++)
            {
                Debug.Log(tileTransforms[i][j].position);
            }
        }
    }
}
