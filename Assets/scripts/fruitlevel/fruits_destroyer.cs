using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits_destroyer : MonoBehaviour
{

    public int value3;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fruit"))
        {
            handmadecounter.instance.Missedscore(value3);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("badfruit"))
         {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
        }

    }
}
