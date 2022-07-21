using System;
using UnityEngine;

public class GameEvent : ScriptableObject
{
    public event Action OnEvent;
    
    public void Raise()
    {
        OnEvent?.Invoke();
    }
}
