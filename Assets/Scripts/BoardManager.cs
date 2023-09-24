using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Transform[][] _board;
    public static BoardManager Instance;
    [SerializeField]
    private bool _isABlockDestroyed;


    private void Awake() {
        Instance = this;
    }
    private void Start() {
        _board = BoardSpawner.Instance.GetTileTransforms.Select(x => x.ToArray()).ToArray();
    }

    public Block GetBlock(int rowIndex, int columnIndex)
    {
        if(rowIndex < 0 || rowIndex >= _board.Length || columnIndex < 0 || columnIndex >= _board[rowIndex].Length)
        {
            return null;
        }
        return _board[rowIndex][columnIndex].GetComponentInChildren<Block>();
    }

    public void SetIsAblockDestroyed(bool value)
    {
        _isABlockDestroyed = value;
    }
    public bool GetIsABlockDestroyed()
    {
        return _isABlockDestroyed;
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

    public bool CheckAllTilesWithBlocksAreSettledWithoutThisBlock(Block block)
    {
        for (int i = 0; i < _board.Length; i++)
        {
            for (int j = 0; j < _board[i].Length; j++)
            {
                if(_board[i][j].childCount != 0)
                {
                    if(_board[i][j].GetComponentInChildren<Block>().GetIsSettled() == false && _board[i][j].GetComponentInChildren<Block>() != block)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    public bool IsAboveTileEmpty(int rowIndex, int columnIndex)
    {
        if ( rowIndex != _board[columnIndex].Length && _board[columnIndex][rowIndex].childCount == 0 )
        {
            return true;
        }
        return false;
    }

    public Block GetBlockRight(Block block)
    {
        return GetBlock(block.GetBlockCurrentColumnIndex() + 1, block.GetBlockCurrentRowIndex());
    }
    public Block GetBlockLeft(Block block)
    {
        return GetBlock(block.GetBlockCurrentColumnIndex() - 1, block.GetBlockCurrentRowIndex());
    }
    public Block GetBlockAbove(Block block)
    {
        return GetBlock(block.GetBlockCurrentColumnIndex(), block.GetBlockCurrentRowIndex() + 1);
    }

    #region GetAdjacentBlockValues
        public int GetBlockRightValue(Block block)
    {
        Block _blockRight = GetBlock(block.GetBlockCurrentColumnIndex() + 1, block.GetBlockCurrentRowIndex());
        if(_blockRight == null)
        {
            return 0;
        }
        
        return _blockRight.GetBlockValue();
    }

    public int GetBlockLeftValue(Block block)
    {
        Block _blockLeft = GetBlock(block.GetBlockCurrentColumnIndex() - 1, block.GetBlockCurrentRowIndex());
        if(_blockLeft == null)
        {
            return 0;
        }
        return _blockLeft.GetBlockValue();
    }
    public int GetBlockAboveValue(Block block)
    {
        Block _blockAbove = GetBlock(block.GetBlockCurrentColumnIndex(), block.GetBlockCurrentRowIndex() + 1);
        if(_blockAbove == null)
        {
            return 0;
        }
        return _blockAbove.GetBlockValue();
    }
    #endregion

    public void DestroyBlock(Block block)
    {
        Destroy(block.gameObject);
    }
}
