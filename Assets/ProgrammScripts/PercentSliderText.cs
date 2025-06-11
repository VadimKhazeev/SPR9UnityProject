using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentSliderText : MonoBehaviour
{
    Text percentageText;
    void Start()
    {
        percentageText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 2) + "%";
    }
}
