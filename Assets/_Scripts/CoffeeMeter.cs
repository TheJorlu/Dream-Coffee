using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class CoffeeMeter : MonoBehaviour
{
    public bool isChanging;

    private Image meterFill;
    private Animation anim;

    private void Start()
    {
        meterFill = GetComponent<Image>();
        anim = GetComponent<Animation>();
    }

    [YarnCommand("rateCoffee")]
    public void UpdateMeter(string value)
    {
        StartCoroutine(DisplayMeter(float.Parse(value) / 100));
    }

    IEnumerator DisplayMeter(float fillValue)
    {
        isChanging = true;
        yield return new WaitForSeconds(.5f);

        anim.PlayNormal(1);

        do
        {
            meterFill.fillAmount = Mathf.Lerp(meterFill.fillAmount, fillValue, Time.deltaTime);
            yield return 0;
        }
        while (System.Math.Abs(meterFill.fillAmount - fillValue) > 0.01f);

        anim.PlayBackwards(1);
        isChanging = false;
    }
}
