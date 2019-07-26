using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SmoothChangingOfNumber : MonoBehaviour
{
    [SerializeField] [Range(2, 10)] private int speed = 2;

    public ulong TargetValue
    {
        get { return targetValue; }
        set
        {
            if (value > 0 && value < ulong.MaxValue) targetValue = value;
        }
    }
    private TextMeshProUGUI text;

    [Header("Debug")]
    [SerializeField] private bool isChanging = false;
    [SerializeField] private ulong coefficient;
    [SerializeField] private ulong currentValue;
    [SerializeField] private ulong targetValue;
    [SerializeField] private ulong difference;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetInitValues(ulong currentValue, ulong targetValue)
    {
        this.currentValue = currentValue;
        this.targetValue = targetValue;
        text.text = currentValue.ToString();
    }

    private void FixedUpdate()
    {
        if (!isChanging && (currentValue != targetValue)) StartCoroutine(SmoothChanging());
    }

    private IEnumerator SmoothChanging()
    {
        isChanging = true;

        while (currentValue != targetValue)
        {
            yield return new WaitForSeconds(0.05f);

            // Получаем разницу между текущич значением и нужным для вычисления коефицента
            if (targetValue > currentValue) difference = targetValue - currentValue;
            else difference = currentValue - targetValue;

            // Вычисляем коефицент
            coefficient = difference / (ulong)speed;
            if (coefficient < 1) coefficient = 1;

            if (currentValue > targetValue) currentValue -= coefficient;
            else currentValue += coefficient;

            text.text = currentValue.ToString();
        }

        isChanging = false;
        coefficient = 1;
    }
}
