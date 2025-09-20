using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killafterS : MonoBehaviour
{
    public int respawnSceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RespawnAfterDelay());
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(0.7f); // Wait for 1 second

        // Load the specified scene after the delay
        SceneManager.LoadScene(respawnSceneIndex);
    }
}
