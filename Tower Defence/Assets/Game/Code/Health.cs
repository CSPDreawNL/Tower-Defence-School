using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int HitPoints;
    public TextMeshProUGUI healthUI;

    public UnityEvent OnHealthZero;

    private void Start()
    {
        if (healthUI)
        {
            healthUI.text = HitPoints.ToString();
        }
    }

    public void ModifyHealth(int _hp)
    {
        HitPoints += _hp;

        if (healthUI)
        {
            healthUI.text = HitPoints.ToString();
        }

        if (HitPoints <= 0)
        {
            OnHealthZero.Invoke();
            Destroy(gameObject);
        }
    }
}
