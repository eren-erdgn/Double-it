using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Merge : BaseState
{

    Block _block;
    BoardManager _boardManager;
    BlockProperties[] _blockProperties;
    private List <Block> _blocksToDestroy = new();
    private bool _isAboveTileEmpty;

    public override void EnterState(StateManager block)
    {
        _block = block.GetComponent<Block>();
        _boardManager = BoardManager.Instance;
        _blockProperties = BlockPropertiesData.Instance.GetBlockProperties();
        _block.SetIsMerging(true);
        block.StartCoroutine(MergeProcess(block));
    }

    private IEnumerator MergeProcess(StateManager block)
    {
        DrawLines();

        yield return new WaitForSeconds(5f);

        MergeWithSameBlock(block);
    }

    public override void UpdateState(StateManager block)
    {
        
        
    }

    void MergeWithSameBlock(StateManager block)
    {   
        int mergableBlockCount = 0;
        int currentBlockPropertiesIndex = _block.GetCurrentBlockPropertiesIndex();
        if(_boardManager.GetBlockAboveValue(_block) == _block.GetBlockValue())
        { 
            mergableBlockCount++;
            _blocksToDestroy.Add(_boardManager.GetBlockAbove(_block));
        }
        if(_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue())
        {
            mergableBlockCount++;
            _blocksToDestroy.Add(_boardManager.GetBlockLeft(_block));
        }
        if(_boardManager.GetBlockRightValue(_block) == _block.GetBlockValue())
        {
            mergableBlockCount++;
            _blocksToDestroy.Add(_boardManager.GetBlockRight(_block));
        }

        DestroyBlocksOnList(_blocksToDestroy);
        CleanList();
        _block.SetCurrentBlockPropertiesIndex(currentBlockPropertiesIndex + mergableBlockCount);
        _block.UpdateMergedBlockProperties(_blockProperties[currentBlockPropertiesIndex + mergableBlockCount]);
        if(_isAboveTileEmpty)
        {
            block.SwitchState(block.MovingState);
            _isAboveTileEmpty = false;
        }
        else
        {
            block.SwitchState(block.SettleState);
        }
        
        _block.SetIsMerging(false);
    }

    void DrawLines()
    {
        if(_boardManager.GetBlockAboveValue(_block) == _block.GetBlockValue())
        { 
            _isAboveTileEmpty = true;
            DrawLine(_block.transform.position, _boardManager.GetBlockAbove(_block).transform.position);
        }
        if(_boardManager.GetBlockLeftValue(_block) == _block.GetBlockValue())
        {
            DrawLine(_block.transform.position, _boardManager.GetBlockLeft(_block).transform.position);
        }
        if(_boardManager.GetBlockRightValue(_block) == _block.GetBlockValue())
        {
            DrawLine(_block.transform.position, _boardManager.GetBlockRight(_block).transform.position);
        }
    }

    void DestroyBlocksOnList(List<Block> blocksToDestroy)
    {
        foreach (var block in blocksToDestroy)
        {
            _boardManager.DestroyBlock(block);
        }
    }
    void CleanList()
    {
        _blocksToDestroy.Clear();
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        Debug.DrawLine(start, end, Color.red, 1f);
    }
}