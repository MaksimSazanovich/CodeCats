using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    public void ShowValue(int value)
    {
        if (value == 0) coinText.text = ");";
        else coinText.text = value.ToString();
    }
}