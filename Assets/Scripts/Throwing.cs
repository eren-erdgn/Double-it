using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    private Block _block;
    private BoardManager _boardManager;
    private Transform[][] _targetPositions;
    
    private int _targetR;
    private int _targetCol;
    
    private bool _isThrowable;
    private bool _isMoving;
    private void OnEnable()
    {
        Events.OnBlockThrowing.AddListener(OnThrowing);
        
        
    }

    private void OnDisable()
    {
        Events.OnBlockThrowing.RemoveListener(OnThrowing);
    }

    private void Update()
    {
        if(_isThrowable==false) return;
        if (_isMoving)
        {
            MoveUp(_targetR, _targetCol, 5f);
        }
    }
    private void IntroduceVariables()
    {
        _boardManager = BoardManager.Instance;
        _targetPositions = BoardSpawner.Instance.GetTileTransforms.Select(x => x.ToArray()).ToArray();
        _targetR = _boardManager.GetFirstEmptyRowIndex(_block.GetBlockCurrentColumnIndex());
        _targetCol = _block.GetBlockCurrentColumnIndex();
    }
    private void OnThrowing()
    {
        _block = GetComponent<Block>();
        
        if(Block.BlockType.Throwing == _block.GetBlockType())
        {
            IntroduceVariables();
            CheckColumn();
            _isThrowable = true;
        }
        
        
    }
    private void CheckColumn()
    {
        if(_boardManager.GetFirstEmptyRowIndex(_block.GetBlockCurrentColumnIndex()) == -1)
        {
            StateManager.Instance.ChangeState(GameState.Lose);
        }
        else
        {
            _isMoving = true;
            
        }
    }
    private void MoveUp(int targetRow, int targetColumn, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPositions[targetColumn][targetRow].position, speed * Time.deltaTime);
        if(transform.position == _targetPositions[targetColumn][targetRow].position)
        {
            _block.SetBlockCurrentRowIndex(targetRow);
            transform.parent = _targetPositions[targetColumn][targetRow];
            _block.SetBlockType(Block.BlockType.CheckMerge);
            StateManager.Instance.ChangeState(GameState.Merging);
            _isThrowable = false;
            _isMoving = false;
            
        }
    }
}
