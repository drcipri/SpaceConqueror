using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [SerializeField]Slider slider;
    [SerializeField]Gradient gradient;
    [SerializeField] Image healthImage;
 

    

    public void SetMaxHealth(float health)
    {
        
        slider.maxValue = health;
        slider.value = health;

        healthImage.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        healthImage.color = gradient.Evaluate(slider.normalizedValue);
    }
}
