using TMPro;
using UnityEngine;
using UnityEngine.UI;

class GameResourceDisplay : MonoBehaviour
{
    [SerializeField] private GameResource _gameResource;
    public GameResource GameResource
    {
        get => _gameResource;
        set
        {
            _gameResource = value;
            UpdateUI();
            _gameResource.OnValueChanged += (_) => UpdateUI();
        }
    }

    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    private void UpdateUI()
    {
        _image.sprite = GameResourceManager.GetSpriteByIndex(GameResource.GameResourceId);
        _text.text = GameResource.Value.ToString();
    }
}
