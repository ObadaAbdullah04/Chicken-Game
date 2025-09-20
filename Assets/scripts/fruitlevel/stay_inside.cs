using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stay_inside : MonoBehaviour
{
    void Update()
    {
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 2f),
                Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
        }
    }
}
