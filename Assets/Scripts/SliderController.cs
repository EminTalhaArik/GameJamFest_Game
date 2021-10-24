using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public void SetSliderValue(float value)
    {
        GetComponent<Slider>().value = value;
    }
}
