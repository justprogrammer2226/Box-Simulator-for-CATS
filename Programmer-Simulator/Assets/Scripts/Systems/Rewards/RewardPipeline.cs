using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RewardPipeline : MonoBehaviour, IPointerDownHandler
{
    [Header("Settings")]
    [SerializeField] private GameObject _rewardPrefab;
    [SerializeField] private GameObject _rewardPanel;

    private Queue<GameResource> _rewardMiddlewares;
    private GameObject _currentMiddleware;

    public void Display(List<GameResource> rewards)
    {
        _rewardMiddlewares = new Queue<GameResource>(rewards);
        _rewardPanel.SetActive(true);
        NextMiddleware();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        NextMiddleware();
    }

    private void NextMiddleware()
    {
        if(_rewardMiddlewares.Count != 0)
        {
            Destroy(_currentMiddleware);
            RewardDisplay rewardDisplay = Instantiate(_rewardPrefab, _rewardPanel.transform).GetComponent<RewardDisplay>();
            rewardDisplay.GameResource = _rewardMiddlewares.Dequeue();
            _currentMiddleware = rewardDisplay.gameObject;
        }
        else
        {
            Destroy(_currentMiddleware);
            _rewardPanel.SetActive(false);
        }
    }
}
