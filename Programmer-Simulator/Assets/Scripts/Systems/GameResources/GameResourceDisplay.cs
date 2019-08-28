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
            if(_gameResource != null && value == null)
            {
                _gameResource.OnValueChanged -= (_) => UpdateUI();
            }
            _gameResource = value;
            UpdateUI();
            _gameResource.OnValueChanged += (_) => UpdateUI();
        }
    }

    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    private void UpdateUI()
    {
        _image.sprite = GameResource.GameResourceData.Sprite;

        GameResourceType type = GameResource.GameResourceData.Type;

        if (type == GameResourceType.Box)
        {
            if(GameResource.Value == GameResource.GameResourceData.TargetValue)
            {
                _image.color = new Color(1, 1, 1);
                _text.text = string.Empty;
            }
            else
            {
                _image.color = new Color(100f / 255, 100f /255, 100f / 255);
                _text.text = $"{GameResource.Value}/{GameResource.GameResourceData.TargetValue}";
            }
        }
        else if (type == GameResourceType.Player)
        {
            _text.text = GameResource.Value.ToString();
        }
    }
}
