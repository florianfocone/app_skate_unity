using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerchange : MonoBehaviour
{
    public Slider mainSlider;
    private Text powertext;
    public static int powerint = 1;
    
    public Slider sliderDessus;
    int progressPower = 0;

     void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
     
        powertext = GetComponent<Text>();
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        powerint = (int)mainSlider.value;
      //  Debug.Log("power : " + powerint);

        powertext.text = powerint.ToString();

    }

     void Update()
    {
     
        progressPower = vitessecalcul.vitesseint;
        Debug.Log(progressPower);
        sliderDessus.value = progressPower;
    }
}
