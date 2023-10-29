using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Merging : MonoBehaviour
{
    private  Block _block;
    private void OnEnable()
    {
        Events.OnBlockCheckMerge.AddListener(CheckMerge);
    }

    private void OnDisable()
    {
        Events.OnBlockCheckMerge.RemoveListener(CheckMerge);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void CheckMerge()
    {
        _block = GetComponent<Block>();
        IntroduceVariables();
    }

    private void IntroduceVariables()
    {
        if(Block.BlockType.CheckMerge != _block.GetBlockType()) return;
        
        Debug.Log("merge");
        foreach (var adjBlock  in BoardManager.Instance.CheckAdjacentBlockAndDebug(_block.GetBlockCurrentColumnIndex(),_block.GetBlockCurrentRowIndex()))
        {
            if (adjBlock == null) continue;
            
            Debug.Log(adjBlock.GetBlockNumber());  
        }
        _block.SetBlockType(Block.BlockType.Settled);
        StateManager.Instance.ChangeState(GameState.SpawnBlock);
        
    }
    


}
