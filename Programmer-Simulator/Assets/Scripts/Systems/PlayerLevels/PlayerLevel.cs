using UnityEngine;

[System.Serializable]
class PlayerLevel
{
    [SerializeField] private int _targetExperience;
    public int TargetExperience => _targetExperience;

    [SerializeField] private PlayerGameResource[] _rewards;
    public PlayerGameResource[] Rewards => _rewards;
}
