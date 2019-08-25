using TMPro;
using UnityEngine;
using UnityEngine.UI;

class RewardDisplay : MonoBehaviour
{
    [SerializeField] private GameResource _gameResource;
    public GameResource GameResource
    {
        get => _gameResource;
        set
        {
            if (_gameResource != null && value == null)
            {
                _gameResource.OnValueChanged -= (_) => UpdateUI();
            }
            _gameResource = value;
            UpdateUI();
            _gameResource.OnValueChanged += (_) => UpdateUI();
        }
    }

    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _valueText;

    private void UpdateUI()
    {
        _image.sprite = GameResource.GameResourceData.Sprite;
        _valueText.text = GameResource.Value.ToString();
        _title.text = GameResource.GameResourceData.Title;
    }
}
