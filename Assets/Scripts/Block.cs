using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{   
    public BlockProperties blockProperties { get; private set; }
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
    
}
