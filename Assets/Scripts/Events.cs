using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static readonly EventActions<int> onTopNumberChanged = new EventActions<int>();
    public static readonly EventActions<int> onColumnSelected = new EventActions<int>();
    public static readonly EventActions<Transform> onSendAvailablePosition = new EventActions<Transform>();
}
