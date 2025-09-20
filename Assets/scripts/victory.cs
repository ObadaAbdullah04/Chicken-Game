using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public int SceneNumber;

    public void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
     {
        SceneManager.LoadScene(SceneNumber);
     }
    }
}
