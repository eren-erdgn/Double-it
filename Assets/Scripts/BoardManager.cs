using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Transform[][] _board;
    private void Start() {
        _board = BoardSpawner.Instance.getTileTransforms.Select(x => x.ToArray()).ToArray();
    }
    
    
}
