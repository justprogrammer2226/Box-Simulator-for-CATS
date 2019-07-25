using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    [SerializeField] private string _title;
    public string Title => _title;

    [SerializeField] private int _id;
    public int Id => _id;

    [SerializeField] private int _targetValue;
    public int TargetValue => _targetValue;

    [SerializeField] private int _currentValue;
    public int CurrentValue
    {
        get => _currentValue;
        set => _currentValue = value;
    }

    [SerializeField] private PlayerGameResource[] _rewards;
    public PlayerGameResource[] Rewards => _rewards;

    [SerializeField] private bool _isClaimed;
    public bool IsClaimed
    {
        get => _isClaimed;
        set => _isClaimed = value;
    }
}
