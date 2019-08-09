using UnityEngine;

[CreateAssetMenu(fileName = "New Player Item", menuName = "Player Item")]
public class PlayerItemData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
}
