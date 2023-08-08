using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{   
    private TextMeshPro _text;
    private SpriteRenderer _spriteRenderer;
    private void Awake() {
        _text = GetComponentInChildren<TextMeshPro>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBlockProperties(BlockProperties blockProperties) {

        
        _text.text = blockProperties.number.ToString();
        _text.color = blockProperties.textColor;
        _spriteRenderer.color = blockProperties.backgroundColor;
    }
    public int GetBlockNumber() {
        return _text.text == "" ? 0 : int.Parse(_text.text);
    }
    
}
