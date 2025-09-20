using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeder : MonoBehaviour
{
    public static Speeder Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
    //another code for repeating every second 
    /*
        StartCoroutine(RepeatEverySecond());  //put it in start

         private IEnumerator RepeatEverySecond()
    {
        while (true)
        {
            YourMethod();
            yield return new WaitForSeconds(1f);
        }
    }

    private void YourMethod()
    {
        // Your code to be executed every second goes here.
    }  
    */


}
