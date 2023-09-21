using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPropertiesData : MonoBehaviour
{
    [SerializeField] private BlockProperties[] _blockProperties;
    public static BlockPropertiesData Instance;
    
    private void Awake() {
        Instance = this;
    }
    public BlockProperties[] GetBlockProperties() {
        return _blockProperties;
    }
}
