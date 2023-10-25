using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BlockPropertiesData : MonoBehaviour
{
    [SerializeField] private BlockProperties[] blockProperties;
    public static BlockPropertiesData Instance;
    
    private void Awake() {
        Instance = this;
    }
    public BlockProperties[] GetBlockProperties() {
        return blockProperties;
    }
}
