using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow2d : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float timeOffset;
    [SerializeField]
    Vector2 posOffset;
    private Vector3 velocity;
    [SerializeField]
    float leftlimit;
    [SerializeField]
    float rightlimit;
    [SerializeField]
    float bottomlimit;
    [SerializeField]
    float toplimit;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos=transform.position;
        Vector3 endPos=Player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        transform.position=Vector3.Lerp(startPos,endPos,timeOffset*Time.deltaTime);
        transform.position=new Vector3(Player.transform.position.x,Player.transform.position.y,-10);
        transform.position=Vector3.SmoothDamp(startPos,endPos,ref velocity,timeOffset);

        transform.position=  new Vector3
        (
            Mathf.Clamp(transform.position.x, leftlimit, rightlimit),
            Mathf.Clamp(transform.position.x, bottomlimit, toplimit),
            transform.position.z
        );
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawLine(new Vector2(leftlimit,toplimit),new Vector2(rightlimit,toplimit));
        Gizmos.DrawLine(new Vector2(rightlimit,toplimit),new Vector2(rightlimit,bottomlimit));
        Gizmos.DrawLine(new Vector2(rightlimit,bottomlimit),new Vector2(leftlimit,bottomlimit));
        Gizmos.DrawLine(new Vector2(leftlimit,bottomlimit),new Vector2(leftlimit,toplimit));

    }
}
