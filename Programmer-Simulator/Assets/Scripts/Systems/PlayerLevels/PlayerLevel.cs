using UnityEngine;

[System.Serializable]
class PlayerLevel
{
    [SerializeField] private int _targetExperience;
    public int TargetExperience => _targetExperience;

    [SerializeField] private GameResource[] _rewards;
    public GameResource[] Rewards => _rewards;
}
