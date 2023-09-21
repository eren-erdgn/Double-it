using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{   
    private TextMeshPro _text;
    private SpriteRenderer _spriteRenderer;
    


    [SerializeField] private bool _isColumnChoosing;
    [SerializeField] private bool _isMoving;
    [SerializeField] private bool _isMerging;
    [SerializeField] private bool _isSetteled;

    [SerializeField] private bool _isAboveBlockMovingAboveTile;

    [SerializeField]private int _currentBlockPropertiesIndex;
    [SerializeField]private int _blockCurrentColumnIndex;
    [SerializeField]private int _blockCurrentRowIndex;


    private void Awake() {
        _text = GetComponentInChildren<TextMeshPro>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBlockProperties(BlockProperties blockProperties) {

        
        _text.text = blockProperties.number.ToString();
        _text.color = blockProperties.textColor;
        _spriteRenderer.color = blockProperties.backgroundColor;
    }
    public void UpdateMergedBlockProperties(BlockProperties blockProperties) {
        _text.text = blockProperties.number.ToString();
        _text.color = blockProperties.textColor;
        _spriteRenderer.color = blockProperties.backgroundColor;
    }

    public void SetCurrentBlockPropertiesIndex(int index) {
        _currentBlockPropertiesIndex = index;
    }
    public int GetCurrentBlockPropertiesIndex() {
        return _currentBlockPropertiesIndex;
    }

    public void SetBlockCurrentColumnIndex(int index) {
        _blockCurrentColumnIndex = index;
    }
    public void SetBlockCurrentRowIndex(int index) {
        _blockCurrentRowIndex = index;
    }
    public int GetBlockCurrentColumnIndex() {
        return _blockCurrentColumnIndex;
    }
    public int GetBlockCurrentRowIndex() {
        return _blockCurrentRowIndex;
    }

    #region stateinfo
    public void SetIsColumnChoosing(bool value) {
        _isColumnChoosing = value;
    }
    public void SetIsMoving(bool value) {
        _isMoving = value;
    }
    public void SetIsMerging(bool value) {
        _isMerging = value;
    }
    public void SetIsSetteled(bool value) {
        _isSetteled = value;
    }
    #endregion
    

    
    public void DestroyBlock(Block block) {
        Destroy(block.gameObject);
    }

    public int GetBlockValue()
    {
        return int.Parse(_text.text);
    }

}
