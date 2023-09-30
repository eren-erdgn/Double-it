using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Settle : BaseState
{
    Block _block;
    BoardManager _boardManager;

    public override void EnterState(StateManager block)
    {   
        _block = block.GetComponent<Block>();
        _boardManager = BoardManager.Instance;
        _block.SetIsSetteled(true);
        CheckTwoMergeableBlocks(block);
        CheckThreeMergeableBlocks(block);
        if(!block.CheckPreviousState(block.MoveAboveTileState))
        {
            CheckMergeableBlocks(block);
        }
    }

    public override void UpdateState(StateManager block)
    {
        if(_boardManager.CheckAllTilesWithBlocksAreSettledWithoutThisBlock(_block))
        {
            
            CheckMergeableBlocks(block);
            CheckOneAboveTile(block);
        }
        
    }

    private void CheckThreeMergeableBlocks(StateManager block)
    {
        if(_boardManager.GetBlockAboveValue(_block) == _block.GetBlockValue() && _boardManager.GetBlockRightValue(_block) == _block.GetBlockValue() &&_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue() )
        {   
            _block.SetIsSetteled(false);
            block.SwitchState(block.MergeState);
            
        }

        else
        {
            return;
        }
    }
    private void CheckTwoMergeableBlocks(StateManager block)
    {
        if((_boardManager.GetBlockRightValue(_block) == _block.GetBlockValue() &&_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue())||(_boardManager.GetBlockAboveValue(_block) == _block.GetBlockValue() &&_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue())||(_boardManager.GetBlockRightValue(_block) == _block.GetBlockValue() &&_boardManager.GetBlockAboveValue(_block) == _block.GetBlockValue()) )
        {   
            _block.SetIsSetteled(false);
            block.SwitchState(block.MergeState);
            
        }

        else
        {
            return;
        }
    }
    private void CheckMergeableBlocks(StateManager block)
    {
        if(_boardManager.GetBlockBelowValue(_block) == _block.GetBlockValue() || _boardManager.GetBlockRightValue(_block) == _block.GetBlockValue() ||_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue() )
        {   
            _block.SetIsSetteled(false);
            block.SwitchState(block.MergeState);
            
        }

        else
        {
            return;
        }
    }

    private void CheckOneAboveTile(StateManager block)
    {   
        int currentRow = _block.GetBlockCurrentRowIndex();
        int currentColumn = _block.GetBlockCurrentColumnIndex();
        if(_boardManager.IsAboveTileEmpty(currentRow + 1, currentColumn))
        {
            
            _block.SetIsSetteled(false);
            block.SwitchState(block.MoveAboveTileState);
            
        }
        else
        {
            return;
        }
    }


}
