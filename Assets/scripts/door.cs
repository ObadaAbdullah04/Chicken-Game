using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Animator doorAnimator;
    public int SceneNumber;

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("isopen");
            yield return new WaitForSeconds(1.3f); // Wait for 2 seconds
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
