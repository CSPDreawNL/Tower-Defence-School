using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;

    public TextMeshProUGUI CurrencyUI;
    public TextMeshProUGUI WaveUI;
    public GameObject NextLevelUI;
    public GameObject GameOverUI;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateCurrency()
    {
        CurrencyUI.text = string.Format("Currency: {0}", GameManager.instance.Currency);
    }

    public void ShowGameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void ShowNextLevel()
    {
        NextLevelUI.SetActive(true);
    }
}
