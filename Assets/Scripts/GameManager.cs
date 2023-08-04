using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _topNumberAtBoard;
    private void Start() {
        Events.onTopNumberChanged.Invoke(_topNumberAtBoard);
    }
    
      
 

    
}