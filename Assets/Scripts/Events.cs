using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static readonly EventActions OnBlockSpawned = new EventActions();
    public static readonly EventActions OnBlockListen = new EventActions();
    public static readonly EventActions OnBlockThrowing = new EventActions();
    public static readonly EventActions OnBlockCheckMerge = new EventActions();
}
