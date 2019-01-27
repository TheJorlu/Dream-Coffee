using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class CoffeeMeter : MonoBehaviour
{
    public Image cupProgressImage;
    public Sprite[] cupProgressSprites;
    [HideInInspector]public bool isChanging;

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
        if(fillValue < 0.1f)
        {
            meterFill.fillAmount = 0;
            yield break;
        }

        isChanging = true;
        yield return new WaitForSeconds(.5f);

        anim.PlayNormal(1);

        do
        {
            meterFill.fillAmount = Mathf.Lerp(meterFill.fillAmount, fillValue, Time.deltaTime);

            if (meterFill.fillAmount < .25f)
                cupProgressImage.sprite = cupProgressSprites[0];
            else if (meterFill.fillAmount < .75f)
                cupProgressImage.sprite = cupProgressSprites[1];
            else
                cupProgressImage.sprite = cupProgressSprites[2];

            yield return 0;
        }
        while (System.Math.Abs(meterFill.fillAmount - fillValue) > 0.01f && !Input.anyKey);

        meterFill.fillAmount = fillValue;

        yield return new WaitForSeconds(.2f);

        anim.PlayBackwards(1);
        isChanging = false;
    }
}
