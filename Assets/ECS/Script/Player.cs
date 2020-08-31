using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static readonly int isMovingId = Animator.StringToHash("IsMoving");

    Animator animator;

    float moveSpeed = 3f;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if(x != 0 || y != 0)
        {
            transform.position += new Vector3(x, y, z: 0) * (Time.deltaTime * moveSpeed);
        
            if(!isMoving)
            {
                isMoving = true;
                animator.SetBool(isMovingId, isMoving);
            }
        }
        else
        {
            if(isMoving)
            {
                isMoving = false;
                animator.SetBool(isMovingId, isMoving);
            }
        }
    }
}
