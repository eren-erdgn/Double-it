using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnChoosing : BaseState
{
    Block _block;
    BoardManager _boardManager;
    private bool _isDragging = false;
    private Vector3 _initialPosition;
    private Transform[] _targetPositions;

    private int _minTargetIndex = 0;
    private int _maxTargetIndex = 0;
    public override void EnterState(StateManager block)
    {
        _block = block.GetComponent<Block>();
        _block.SetIsColumnChoosing(true);
        _boardManager = BoardManager.Instance;
        _targetPositions = BoardSpawner.Instance.GetChoosingTileTransforms.ToArray();
        if (_targetPositions.Length > 0)
        {
            _minTargetIndex = 0;
            _maxTargetIndex = _targetPositions.Length - 1;
        }
    }

    public override void UpdateState(StateManager block)
    {
        InputListeners(block);
        if (_isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = block.transform.position.z;
            mousePosition.y = block.transform.position.y;

            mousePosition.x = Mathf.Clamp(mousePosition.x, _targetPositions[_minTargetIndex].position.x, _targetPositions[_maxTargetIndex].position.x);

            block.transform.position = mousePosition;
        }
    }
    void InputListeners(StateManager block)
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _initialPosition = block.transform.position;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _isDragging = false;

            float minDistance = float.MaxValue;
            int closestTargetIndex = -1;
            for (int i = _minTargetIndex; i <= _maxTargetIndex; i++)
            {
                float distance = Vector3.Distance(block.transform.position, _targetPositions[i].position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTargetIndex = i;
                }
            }
            if (closestTargetIndex != -1 && minDistance < 0.5f)
            {
                block.transform.position = _targetPositions[closestTargetIndex].position;
                _block.SetBlockCurrentColumnIndex(closestTargetIndex);
                _block.SetIsColumnChoosing(false);
                block.SwitchState(block.MovingState);
            }
            else
            {
                
                block.transform.position = _initialPosition;
            }
        }
    }
    
}

