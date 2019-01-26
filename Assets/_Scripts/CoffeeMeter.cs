using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class CoffeeMeter : MonoBehaviour
{
    private Image meterFill;

    private void Start()
    {
        meterFill = GetComponent<Image>();
    }

    [YarnCommand("rateCoffee")]
    public void UpdateMeter(string value)
    {
        meterFill.fillAmount = float.Parse(value) / 100;
    }
}
