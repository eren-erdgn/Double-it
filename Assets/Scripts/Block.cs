
using System;
using TMPro;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class Block : MonoBehaviour
{   
    public enum BlockType
    {
        NewComer,
        Throwing,
        CheckMerge,
        Merged,
        Settled
    }
    [SerializeField]
    private BlockType blockType;
    
    private TextMeshPro _text;
    private SpriteRenderer _spriteRenderer;
    


     [SerializeField]private int currentBlockPropertiesIndex;
     [SerializeField]private int blockCurrentColumnIndex;
     [SerializeField]private int blockCurrentRowIndex;


    private void Awake() {
        _text = GetComponentInChildren<TextMeshPro>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        blockType = BlockType.NewComer;
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
        currentBlockPropertiesIndex = index;
    }
    public int GetCurrentBlockPropertiesIndex() {
        return currentBlockPropertiesIndex;
    }

    public void SetBlockCurrentColumnIndex(int index) {
        blockCurrentColumnIndex = index;
    }
    public void SetBlockCurrentRowIndex(int index) {
        blockCurrentRowIndex = index;
    }
    public int GetBlockCurrentColumnIndex() {
        return blockCurrentColumnIndex;
    }
    public int GetBlockCurrentRowIndex() {
        return blockCurrentRowIndex;
    }
    public BlockType GetBlockType() {
        return blockType;
    }
    public void SetBlockType(BlockType type) {
        blockType = type;
    }

    public string GetBlockNumber()
    {
        return _text.text;
    }
}
