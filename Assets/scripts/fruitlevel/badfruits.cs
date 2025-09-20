using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badfruits : MonoBehaviour
{
    [SerializeField] GameObject[] fruitprefab;
    [SerializeField] float secondspawn;
    [SerializeField] float mintras;
    [SerializeField] float maxtras;
    void Start()
    {
        StartCoroutine(Fruitspawn());
    }
    IEnumerator Fruitspawn()
    {
        while (true)
        {
            var wanted = Random.Range(mintras, maxtras);
            var position = new Vector3(wanted, transform.position.y);

            GameObject gameObject = Instantiate(fruitprefab[Random.Range(0, fruitprefab.Length)],
            position, Quaternion.identity);

            yield return new WaitForSeconds(secondspawn);

        }
    }


}
