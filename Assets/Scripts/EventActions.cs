using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventActions
{
    private event Action Action = delegate{ };

    public void Invoke()
    {
        Action.Invoke();
    }
    public void AddListener(Action listener)
    {
        Action += listener;
    }
    public void RemoveListener(Action listener)
    {
        Action -= listener;
    }
        
}
public class EventActions<T> 
{
    private event Action<T> Action = delegate { };

    public void Invoke(T param)
    {
        Action.Invoke(param);
    }
    public void AddListener(Action<T> listener)
    {
        Action += listener;
    }
    public void RemoveListener(Action<T> listener)
    {
        Action -= listener;
    }
}
