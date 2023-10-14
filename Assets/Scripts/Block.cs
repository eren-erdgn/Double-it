using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{   
    private TextMeshPro _text;
    private SpriteRenderer _spriteRenderer;
    


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

    
}
