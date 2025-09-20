using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;

    private SpriteRenderer sSpriteRenderer;
    private Vector2 startsize;

    private void Start()
    {
        sSpriteRenderer = GetComponent<SpriteRenderer>();

        startsize = new Vector2(sSpriteRenderer.size.x,sSpriteRenderer.size.y);

        
        
    }
    private void Update()
    {
        sSpriteRenderer.size= new Vector2(sSpriteRenderer.size.x + speed * Time.deltaTime, sSpriteRenderer.size.y);

        if (sSpriteRenderer.size.x > width)
        {
            sSpriteRenderer.size = startsize;
        }
    }
}
