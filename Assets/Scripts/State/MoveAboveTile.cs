using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveAboveTile : BaseState
{
    Block _block;
    BoardManager _boardManager;
    private Transform[][] _targetPositions;
    public override void EnterState(StateManager block)
    {
        _block = block.GetComponent<Block>();
        _block.SetIsMoving(true);
        _boardManager = BoardManager.Instance;
        _targetPositions = BoardSpawner.Instance.GetTileTransforms.Select(x => x.ToArray()).ToArray();
    }

    public override void UpdateState(StateManager block)
    {
        MoveAbove(block);
    }

    private void MoveAbove(StateManager block)
    {
        block.transform.parent = null;
        int targetRow = _block.GetBlockCurrentRowIndex() + 1;
        int targetColumn = _block.GetBlockCurrentColumnIndex();
        DrawLine(_block.transform.position, targetColumn, targetRow);
        MoveUp(block, targetRow, targetColumn, 1f);
    }
    void DrawLine(Vector3 start, int targetColumn, int targetRow)
    {
        Debug.DrawLine(start, _targetPositions[targetColumn][targetRow].position, Color.blue);
    }

    private void MoveUp(StateManager block, int targetRow, int targetColumn, float speed)
    {
        block.transform.position = Vector3.MoveTowards(block.transform.position, _targetPositions[targetColumn][targetRow].position, speed * Time.deltaTime);
        if(block.transform.position == _targetPositions[targetColumn][targetRow].position)
        {
            _block.SetBlockCurrentRowIndex(targetRow);
            _block.SetIsMoving(false);
            block.SwitchState(block.SettleState);
            block.transform.parent = _targetPositions[targetColumn][targetRow];
            
        }
    }
}
