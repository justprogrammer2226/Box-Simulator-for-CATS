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
        _image.sprite = GameResourceManager.GetSpriteByIndex(GameResource.Id);

        GameResourceType type = GameResourceManager.GetTypeByIndex(GameResource.Id);

        if (type == GameResourceType.Box)
        {
            _text.text = $"{GameResource.Value}/{GameResourceManager.GetTargetByIndex(GameResource.Id)}";
        }
        else if (type == GameResourceType.Player)
        {
            _text.text = GameResource.Value.ToString();
        }
    }
}
