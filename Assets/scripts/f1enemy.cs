using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1enemy : MonoBehaviour
{
    Vector3 startpos;
    public float speed;
    public float range;
    int dir =1;
    // Start is called before the first frame update
    void Start()
    {
       startpos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>startpos.x+range || transform.position.x<startpos.x)
       {
        dir*=-1;
       } 
        transform.position+=Vector3.right*speed*dir;

    }
}
