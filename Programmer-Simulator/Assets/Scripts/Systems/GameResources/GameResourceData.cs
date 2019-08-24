using UnityEngine;

[CreateAssetMenu(fileName = "New Game Resource Data", menuName = "Game Resource Data")]
public class GameResourceData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField] private GameResourceType _type;
    public GameResourceType Type => _type;

    [SerializeField] private int _targetValue;
    public int TargetValue => _targetValue;
}
