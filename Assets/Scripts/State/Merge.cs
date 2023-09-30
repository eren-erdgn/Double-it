using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Merge : BaseState
{

    Block _block;
    BoardManager _boardManager;
    BlockProperties[] _blockProperties;
    
    private bool _isMerged = false;

    public override void EnterState(StateManager block)
    {
        _block = block.GetComponent<Block>();
        _boardManager = BoardManager.Instance;
        
        _blockProperties = BlockPropertiesData.Instance.GetBlockProperties();
        _block.SetIsMerging(true);
        
    }

    public override void UpdateState(StateManager block)
    {
        
        MergeWithSameBlock(block);
    }

    void MergeWithSameBlock(StateManager block)
    {   
        
        int mergableBlockCount = 0;
        int currentBlockPropertiesIndex = _block.GetCurrentBlockPropertiesIndex();
        if(_boardManager.GetBlockAboveValue(_block) == _block.GetBlockValue())
        { 
            mergableBlockCount++;
            DrawLine(_block.transform.position, _boardManager.GetBlockAbove(_block).transform.position);
            _boardManager.BlocksToDestroy.Add(_boardManager.GetBlockAbove(_block));
        }
        if(_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue())
        {
            mergableBlockCount++;
            DrawLine(_block.transform.position, _boardManager.GetBlockLeft(_block).transform.position);
            _boardManager.BlocksToDestroy.Add(_boardManager.GetBlockLeft(_block));
        }
        if(_boardManager.GetBlockRightValue(_block) == _block.GetBlockValue())
        {
            mergableBlockCount++;
            DrawLine(_block.transform.position, _boardManager.GetBlockRight(_block).transform.position);
            _boardManager.BlocksToDestroy.Add(_boardManager.GetBlockRight(_block));
        }
        if(_boardManager.GetBlockBelowValue(_block) == _block.GetBlockValue())
        {
            mergableBlockCount++;
            DrawLine(_block.transform.position, _boardManager.GetBlockBelow(_block).transform.position);
            _boardManager.BlocksToDestroy.Add(_boardManager.GetBlockBelow(_block));
        }

        if(mergableBlockCount == 0 && (_boardManager.BlocksToDestroy.Count >= 4 || !_boardManager.CheckBlocksToDestroyHaveUniqeBlocks()) )
        {
            block.SwitchState(block.SettleState);
            _block.SetIsMerging(false);
        }

        
        MoveToSameBlock(_boardManager.BlocksToDestroy);
        if(_isMerged)
        {
            DestroyBlocksOnList(_boardManager.BlocksToDestroy);
            CleanList();
            _block.SetCurrentBlockPropertiesIndex(currentBlockPropertiesIndex + mergableBlockCount);
            _block.UpdateMergedBlockProperties(_blockProperties[currentBlockPropertiesIndex + mergableBlockCount]);
            
            block.SwitchState(block.SettleState);
            _block.SetIsMerging(false);
            _isMerged = false;
        }
        
    }
    
    public void ParentlessTheBlocks(List<Block> blocksToDestroy)
    {
        foreach (var block in blocksToDestroy)
        {
            block.transform.parent = null;
        }
    }
    public void MoveToSameBlock(List<Block> blocksToDestroy)
    {
        
        Vector3 targetPosition = _block.transform.position;
        
        foreach (var block in blocksToDestroy)
        {
            block.transform.position = Vector3.MoveTowards(block.transform.position, targetPosition, 0.0001f);
            if(targetPosition ==block.transform.position)
            {
                _isMerged = true;
            }
        }
        
    }
    void DestroyBlocksOnList(List<Block> blocksToDestroy)
    {
        MoveToSameBlock(blocksToDestroy);
        foreach (var block in blocksToDestroy)
        {
            _boardManager.DestroyBlock(block);
        }
    }
    void CleanList()
    {
        _boardManager.BlocksToDestroy.Clear();
        
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        Debug.DrawLine(start, end, Color.red, 3f);
    }
}