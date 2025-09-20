using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.3f;
    private float respawnDelay = 4f; // Adjust this value to set the respawn delay

    [SerializeField] private Rigidbody2D rb;
    private Vector2 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial position and rotation of the platform
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallAndRespawn());
        }
    }

    private IEnumerator FallAndRespawn()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(respawnDelay);

        // Reset the platform to its initial position and rotation
        rb.bodyType = RigidbodyType2D.Static;
        rb.velocity = Vector2.zero;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
