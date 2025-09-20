using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    [SerializeField] GameObject[] fruitprefab;
    [SerializeField] float secondspawn ;
    [SerializeField] float mintras;
    [SerializeField] float maxtras;

    void Start()
    {
        StartCoroutine(Fruitspawn());
        StartCoroutine(RepeatEverySecond());
    }
    IEnumerator Fruitspawn()
    {
        while (true)
        {
            var wanted = Random.Range(mintras,maxtras);
            var position = new Vector3(wanted,transform.position.y);

            GameObject gameObject = Instantiate(fruitprefab[Random.Range(0, fruitprefab.Length)],
            position, Quaternion.identity);

            yield return new WaitForSeconds(secondspawn);

        }
    }
    private IEnumerator RepeatEverySecond()
    {
        while (true)
        {
            YourMethod();
            yield return new WaitForSeconds(7.5f);
        }
    }

    private void YourMethod()
    {
        if (secondspawn>0.8f)
        {
            secondspawn -= 0.09f;
        }
        if (secondspawn > 0.5f)
        {
            secondspawn -= 0.03f;
        }
        if (secondspawn > 0.25f)
        {
            secondspawn -= 0.015f;
        }
    }

}
