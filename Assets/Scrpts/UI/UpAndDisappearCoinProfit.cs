using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UpAndDisappearCoinProfit : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color emptyColor;
    [SerializeField] private Transform startPosition;
    private Transform newParent;
    [SerializeField] private CoinObject coinObject;

    private void Start()
    {
        emptyColor = new Color(1, 1, 1, 0);
        SetHiddenStateParametrs();
        newParent = FindObjectOfType<ProfitImages>().transform;
        transform.SetParent(newParent, true);
        Invoke("UpAndDisappear", 1);
    }

    private void OnEnable()
    {
        coinObject.OnStartToProfitText += ShowText;
    }

    private void OnDisable()
    {
        coinObject.OnStartToProfitText -= ShowText;
    }

    private void SetHiddenStateParametrs()
    {
        spriteRenderer.color = emptyColor;
        textMeshPro.color = emptyColor;
    }

    private void SetStartParametrs()
    {
        transform.position = startPosition.position;
        spriteRenderer.color = Color.white;
        textMeshPro.color = Color.white;
    }

    private void UpAndDisappear()
    {
        if (this.enabled)
        {
            SetStartParametrs();

            transform.DOMoveY(transform.position.y + 0.5f, 1);
            textMeshPro.DOFade(0, 1);
            spriteRenderer.DOFade(0, 1).OnComplete(() => SetHiddenStateParametrs()).OnComplete(() => UpAndDisappear());
        }
    }

    private void ShowText(int value)
    {
        textMeshPro.text =  "+" + value.ToString();
    }
}