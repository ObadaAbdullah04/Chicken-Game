using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCRandomMove : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;
    public float moveSpeed = 1f;
    private Vector2 targetPosition;

    private void Start()
    {
        // Set initial target position
        SetNewTargetPosition();
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Set new target position
            SetNewTargetPosition();
        }
    }

    private void SetNewTargetPosition()
    {
        // Generate random position within specified range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
    }
}
