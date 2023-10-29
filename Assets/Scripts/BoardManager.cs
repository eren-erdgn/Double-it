using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Transform[][] _board;
    public static BoardManager Instance;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        _board = BoardSpawner.Instance.GetTileTransforms.Select(x => x.ToArray()).ToArray();
    }
    public int GetFirstEmptyRowIndex(int columnIndex)
    {   
        for (int i = _board[columnIndex].Length - 1; i >= 0; i--)
        {
            if (_board[columnIndex][i].childCount == 0)
            {
                return i;
            }
        }
        return -1;
    }

    public Block[] CheckAdjacentBlockAndDebug(int columnIndex, int rowIndex)
    {
        Block[] adjacentBlocks = new Block[4];
        if (rowIndex + 1 < _board[columnIndex].Length && _board[columnIndex][rowIndex + 1].childCount != 0)
        {
            adjacentBlocks[0] = _board[columnIndex][rowIndex + 1].GetComponentInChildren<Block>();
        }
        if (rowIndex - 1 >= 0 && _board[columnIndex][rowIndex - 1].childCount != 0)
        {
            adjacentBlocks[1] = _board[columnIndex][rowIndex - 1].GetComponentInChildren<Block>();
        }
        if (columnIndex + 1 < _board.Length && _board[columnIndex + 1][rowIndex].childCount != 0)
        {
            adjacentBlocks[2] = _board[columnIndex + 1][rowIndex].GetComponentInChildren<Block>();
        }
        if (columnIndex - 1 >= 0 && _board[columnIndex - 1][rowIndex].childCount != 0)
        {
            adjacentBlocks[3] = _board[columnIndex - 1][rowIndex].GetComponentInChildren<Block>();
        }
        return adjacentBlocks;
    }
    

    
    
}
