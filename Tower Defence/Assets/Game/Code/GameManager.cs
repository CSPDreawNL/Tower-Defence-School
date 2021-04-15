using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Currency;
    public bool IsGameOver;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        IsGameOver = false;
        InterfaceManager.instance.UpdateCurrency();
    }

    public void ModifyCurrency(int _currency)
    {
        Currency += _currency;
        InterfaceManager.instance.UpdateCurrency();
    }

    public void ShowGameOver()
    {
        IsGameOver = true;
        InterfaceManager.instance.ShowGameOver();
    }
}
