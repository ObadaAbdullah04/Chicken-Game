using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
   public float Health, MaxHealth,Width, Hight ;
   [SerializeField]
   private RectTransform healthBar;
   public void SetMaxHealth (float maxHealth) {
            MaxHealth=maxHealth;


   }




    public void SetHealth (float health) {
        Health=health;
        float newWidth= (Health/MaxHealth)*Width;
        healthBar.sizeDelta =new Vector2(newWidth,Hight);
        
    }

}
