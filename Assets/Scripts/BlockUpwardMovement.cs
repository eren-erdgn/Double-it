using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockUpwardMovement : MonoBehaviour
{
    private bool _isMoving = false;
    private int _columnIndex = 0;
    private Transform[][] _targetPositions;
    [SerializeField] private float _speed = 2f;
    private void OnEnable() {
        Events.onColumnSelected.AddListener(startUpwardMovement);
    }
    private void OnDisable() {
        Events.onColumnSelected.RemoveListener(startUpwardMovement);
    }

    private void Start() {
        
        _targetPositions = BoardSpawner.Instance.getTileTransforms.Select(x => x.ToArray()).ToArray();
    }
    
    private void Update() {
        if (_isMoving)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, _targetPositions[_columnIndex][6].position,_speed * Time.deltaTime);
            if (transform.position == _targetPositions[_columnIndex][6].position)
            {
                _isMoving = false;
            }
        }
    }

    private void startUpwardMovement(int columnIndex)
    {
        _columnIndex = columnIndex;
        _isMoving = true;
    }
}
