using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyHealthbar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image healthImage;




    public void SetMaxHealth(float health)
    {

        slider.maxValue = health;
        slider.value = health;

        
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        
    }
}
