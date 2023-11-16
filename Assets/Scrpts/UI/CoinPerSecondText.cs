using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPerSecondText : MonoBehaviour
{
    [SerializeField] private TMP_Text coinPerSecondText;

    public void ShowValue(int value)
    {
        coinPerSecondText.text = value.ToString() + " монет/сек";
    }
}