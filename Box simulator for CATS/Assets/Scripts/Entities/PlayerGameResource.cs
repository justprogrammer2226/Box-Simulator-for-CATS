using System;
using UnityEngine;

[Serializable]
public class PlayerGameResource
{
    [SerializeField] private GameResource _gameResource;
    public GameResource GameResource => _gameResource;

    [SerializeField] private int _value;
    public int Value
    {
        get => _value;
        set => _value = value;
    }
}
