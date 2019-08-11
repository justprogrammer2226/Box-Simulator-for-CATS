using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Money Data", menuName = "Player Money Data")]
public class PlayerMoneyData : ScriptableObject
{
    [SerializeField] private int _money;
    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            OnMoneyChange?.Invoke(_money);
        }
    }

    [SerializeField] private List<MoneyChanger> _incomeItems;
    public List<MoneyChanger> IncomeItems => _incomeItems;

    [SerializeField] private List<MoneyChanger> _expenseItems;
    public List<MoneyChanger> ExpenseItems => _expenseItems;

    public Action<int> OnMoneyChange;
}

