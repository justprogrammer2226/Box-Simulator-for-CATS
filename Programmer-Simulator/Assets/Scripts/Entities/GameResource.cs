using UnityEngine;

[CreateAssetMenu(fileName = "New Game Resource", menuName = "Game Resource")]
public class GameResource : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
}