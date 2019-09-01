using UnityEngine;

class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _inventoryMenu;
    [SerializeField] private GameObject _achievementsMenu;
    [SerializeField] private GameObject _shopMenu;

    [Header("Debug")]
    private GameObject _lastActiveMenu;

    private void Start()
    {
        _lastActiveMenu = _mainMenu;
    }

    public void ActivateMainMenu()
    {
        if (_lastActiveMenu != null) _lastActiveMenu.SetActive(false);
        _mainMenu.SetActive(true);
        _lastActiveMenu = _mainMenu;
    }

    public void ActivateAchievementsMenu()
    {
        if (_lastActiveMenu != null) _lastActiveMenu.SetActive(false);
        _achievementsMenu.SetActive(true);
        _lastActiveMenu = _achievementsMenu;
    }

    public void ActivateInventoryMenu()
    {
        if (_lastActiveMenu != null) _lastActiveMenu.SetActive(false);
        _inventoryMenu.SetActive(true);
        _lastActiveMenu = _inventoryMenu;
    }

    public void ActivateShopMenu()
    {
        if (_lastActiveMenu != null) _lastActiveMenu.SetActive(false);
        _shopMenu.SetActive(true);
        _lastActiveMenu = _shopMenu;
    }
}
