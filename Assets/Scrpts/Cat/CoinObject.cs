using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class CoinObject : MonoBehaviour
{
    [SerializeField] private int startCoins;
    private int coins;

    [SerializeField] private float timeBetweenProfit;

    public static event Action<int> OnChanged;
    public static event Action<int> OnStart;
    public event Action<int> OnStartToProfitText;
    public static event Action<int> OnDisactive;

    private void Start()
    {
        OnStart?.Invoke(startCoins);
        OnStartToProfitText?.Invoke(startCoins);
        coins = startCoins;
        Invoke("AddCoins", timeBetweenProfit);
    }

    private void AddCoins()
    {
        OnChanged?.Invoke(coins);
        transform.DOScaleY(0.85f, 0.3f).SetEase(Ease.Linear).OnComplete(() => transform.DOScaleY(1, 0.07f).SetEase(Ease.Linear));

        Invoke("AddCoins", timeBetweenProfit);
    }

    private void OnDestroy()
    {
        OnDisactive?.Invoke(-startCoins);
    }
}