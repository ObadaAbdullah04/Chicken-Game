using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public Sprite full,empty;
    Image heartimage;

    private void Awake()
    {
        heartimage=GetComponent<Image>();
    }
    public void setimageheart(heartstatus status)
    {
        switch (status)
        {
            
            case heartstatus.Empty:
              heartimage.sprite=empty;
              break;
            case heartstatus.Full:
              heartimage.sprite=full;
              break;
        }
    }
}
public enum heartstatus
{
    Empty = 0,Full =1
}