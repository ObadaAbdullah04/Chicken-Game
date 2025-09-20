using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1venemy : MonoBehaviour
{
    Vector3 startpos;
    public float speed;
    public float range;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > startpos.y + range || transform.position.y < startpos.y)
        {
            dir *= -1;
        }
        transform.position += Vector3.up * speed * dir * Time.deltaTime;
    }
}
