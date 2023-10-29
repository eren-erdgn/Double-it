using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draging : MonoBehaviour
{
    private Block _block;
    private bool _isAtDragState = false;
    private bool _isDragging = false;
    private Vector3 _initialPosition;
    private Transform[] _targetPositions;
    private int _minTargetIndex = 0;
    private int _maxTargetIndex = 0;
    private void OnEnable()
    {
        
        Events.OnBlockListen.AddListener(Toggle);
    }

    private void OnDisable()
    {
        Events.OnBlockListen.RemoveListener(Toggle);
    }

    private void Start()
    {
        
        
        _targetPositions = BoardSpawner.Instance.GetChoosingTileTransforms.ToArray();
        if (_targetPositions.Length > 0)
        {
            _minTargetIndex = 0;
            _maxTargetIndex = _targetPositions.Length - 1;
        }
    }
    
    private void Update()
    {
        if (_isAtDragState == false ) return;
        InputListener();
        if (_isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var position = transform.position;
            mousePosition.z = position.z;
            mousePosition.y = position.y;

            mousePosition.x = Mathf.Clamp(mousePosition.x, _targetPositions[_minTargetIndex].position.x, _targetPositions[_maxTargetIndex].position.x);

            transform.position = mousePosition;
        }
        
    }

    private void Toggle()
    {
        _block = GetComponent<Block>();
        _isAtDragState = _block.GetBlockType() == Block.BlockType.NewComer;
    }

    
    private void InputListener()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _initialPosition = transform.position;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _isDragging = false;

            float minDistance = float.MaxValue;
            int closestTargetIndex = -1;
            for (int i = _minTargetIndex; i <= _maxTargetIndex; i++)
            {
                float distance = Vector3.Distance(transform.position, _targetPositions[i].position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTargetIndex = i;
                }
            }
            if (closestTargetIndex != -1 && minDistance < 0.5f)
            {
                
                transform.position = _targetPositions[closestTargetIndex].position;
                _block.SetBlockCurrentColumnIndex(closestTargetIndex);
                _isAtDragState = false;
                
                _block.SetBlockType(Block.BlockType.Throwing);
                StateManager.Instance.ChangeState(GameState.Throwing);
                
            }
            else
            {
                
                transform.position = _initialPosition;
            }
        }
    }
}