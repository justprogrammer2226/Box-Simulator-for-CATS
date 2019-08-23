using UnityEngine;

[System.Serializable]
class PlayerLevel
{
    [SerializeField] private int _targetExperience;
    public int TargetExperience => _targetExperience;

    [SerializeField] private BoxItem[] _rewards;
    public BoxItem[] Rewards => _rewards;
}
