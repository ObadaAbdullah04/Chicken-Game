using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxtime;// = 1.5f;
    [SerializeField] private float heightrange = 0.45f;
    [SerializeField] private GameObject pipe;

    private float timer;

    private void Start()
    {
        spawnpipe();

        StartCoroutine(RepeatEverySecond());
    }

    private void Update()
    {
        if (timer > maxtime)
        {
            spawnpipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void spawnpipe()
    {
        Vector3 spawnpos = transform.position + new Vector3(0,Random.Range(-heightrange, heightrange));
        GameObject Pipe = Instantiate( pipe, spawnpos , Quaternion.identity);

        Destroy(Pipe , 10f);
    }
    private IEnumerator RepeatEverySecond()
    {
        while (true)
        {
            YourMethod();
            yield return new WaitForSeconds(10f);
        }
    }

    private void YourMethod()
    {
        if (maxtime > 2.1f)
        { 
        maxtime -= 0.1f;
        }
    }

}
