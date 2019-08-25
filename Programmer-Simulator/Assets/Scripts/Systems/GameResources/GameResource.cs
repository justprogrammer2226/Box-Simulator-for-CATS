using System;
using UnityEngine;

[Serializable]
public class GameResource
{
    [SerializeField] private GameResourceData _gameResourceData;
    public GameResourceData GameResourceData => _gameResourceData;

    [SerializeField] private int _value;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    public event Action<int> OnValueChanged;

    public GameResource(GameResource gameResource)
    {
        _gameResourceData = gameResource._gameResourceData;
        _value = gameResource._value;
    }

    public GameResource(GameResourceData gameResourceData, int value)
    {
        _gameResourceData = gameResourceData;
        _value = value;
    }
}
