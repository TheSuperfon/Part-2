using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    /*public void TakeDamage(float damage)
    {
        slider.value -= damage;


    }*/

    public void startValue(float Starthealth)
    {
        
        slider.value = Starthealth;
        
    }


}
