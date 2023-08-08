using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{

    [SerializeField] private float _width;
    [SerializeField] private int _height;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private List<Transform> choosingTileTransforms = new List<Transform>();
    public static BoardSpawner Instance;

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
        generateChoosingBoard();
        
    }
    public List<Transform> getChoosingTileTransforms { get => choosingTileTransforms; }
    void generateChoosingBoard()
    {
        for (float x = -_width + 1; x < _width; x++)
        {
            _tilePrefab.transform.localScale = new Vector3(1f, 1f, 1f);
            GameObject newTile = Instantiate(_tilePrefab, new Vector2(x, 0), Quaternion.identity);
            choosingTileTransforms.Add(newTile.transform);
        }
    }
    void GenerateBoard()
    {
        for (float x = -_width + 1; x < _width; x++)
        {
            for (float y = 1; y < _height; y++)
            {   
                _tilePrefab.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
    
   
}
