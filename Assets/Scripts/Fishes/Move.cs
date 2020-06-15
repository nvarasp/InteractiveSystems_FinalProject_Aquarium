using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour
{

    public float speed;         // movement speed
    public GameObject follow;   // follow
    private Transform target;   // Target

    // Start is called before the first frame update
    void Start()
    {
        target = follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position,step);
    }
}
