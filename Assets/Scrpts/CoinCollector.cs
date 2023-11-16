using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> CoinChanged;
    [SerializeField] private UnityEvent<int> CoinPerSecondChanged;
    public static int coinCollected;
    public static int coinPerSecondCollected;
    private void Awake()
    {
        coinCollected = 10;
        CoinChanged.Invoke(coinCollected);
    }
    private void OnEnable()
    {
        CoinObject.OnChanged += CoinObject_OnChanged;
        CoinObject.OnStart += CoinObject_OnStartOrDisactive;
        CoinObject.OnDisactive += CoinObject_OnStartOrDisactive;
    }
    private void OnDisable()
    {
        CoinObject.OnChanged -= CoinObject_OnChanged;
        CoinObject.OnStart -= CoinObject_OnStartOrDisactive;
        CoinObject.OnDisactive -= CoinObject_OnStartOrDisactive;
    }

    private void CoinObject_OnChanged(int value)
    {
        coinCollected += value;
        CoinChanged.Invoke(coinCollected);
    }

    private void CoinObject_OnStartOrDisactive(int value)
    {
        coinPerSecondCollected += value;
        CoinPerSecondChanged.Invoke(coinPerSecondCollected);
    }
}