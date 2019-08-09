using UnityEngine;

class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject achievementsMenu;
    public GameObject playerItemsMenu;

    [Header("Debug")]
    private GameObject _lastActiveMenu;

    public void ActivateAchievementsMenu()
    {
        if (_lastActiveMenu != null) _lastActiveMenu.SetActive(false);
        achievementsMenu.SetActive(true);
        _lastActiveMenu = achievementsMenu;
    }

    public void ActivatePlayerItemsMenu()
    {
        if (_lastActiveMenu != null) _lastActiveMenu.SetActive(false);
        playerItemsMenu.SetActive(true);
        _lastActiveMenu = playerItemsMenu;
    }
}
