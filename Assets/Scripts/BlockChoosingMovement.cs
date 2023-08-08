using System.Collections.Generic;
using UnityEngine;

public class BlockChoosingMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition; // Store the initial position of the object
    private Transform[] _targetPositions;

    private int minTargetIndex = 0;
    private int maxTargetIndex = 0;

    private void Start()
    {
        _targetPositions = BoardSpawner.Instance.getChoosingTileTransforms.ToArray();
        if (_targetPositions.Length > 0)
        {
            minTargetIndex = 0;
            maxTargetIndex = _targetPositions.Length - 1;
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = transform.position;
    }

    private void OnMouseUp()
{
    isDragging = false;

    float minDistance = float.MaxValue;
    int closestTargetIndex = -1;

    for (int i = minTargetIndex; i <= maxTargetIndex; i++)
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
        Events.onColumnSelected.Invoke(closestTargetIndex);
        Debug.Log("Snapped to target position index: " + closestTargetIndex);
    }
    else
    {
        
        transform.position = initialPosition;
    }
}

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            mousePosition.y = transform.position.y;

            mousePosition.x = Mathf.Clamp(mousePosition.x, _targetPositions[minTargetIndex].position.x, _targetPositions[maxTargetIndex].position.x);

            transform.position = mousePosition;
        }
    }
}