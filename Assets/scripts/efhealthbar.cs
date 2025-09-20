using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class efhealthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    public void UpdateHealthBar(float currentvalue,float maxvalue)
    {
        slider.value = currentvalue / maxvalue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
