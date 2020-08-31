using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;

    float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FollowTarget()
    {
        if(!target)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(current: transform.position, target.position, maxDistanceDelta: Time.deltaTime * speed);

    }
}
