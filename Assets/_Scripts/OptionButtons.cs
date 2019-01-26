using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class OptionButtons : MonoBehaviour
{
    private GridLayoutGroup layoutGroup;

    private void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
    }

    [YarnCommand("setOptions")]
    public void SetLayout(string value)
    {
        layoutGroup.constraintCount = int.Parse(value);
    }
}
