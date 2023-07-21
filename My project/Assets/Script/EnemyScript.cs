using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float timerMove;
    

    void Update()
    {    

    }

    public void Timer()
    {
        if(timerMove > 0)
        {
            timerMove = timerMove - Time.deltaTime();
        }
    }

    public void EnemyMove()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if ()
        {
            inputVector.x = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, 1));
        }
        if ()
        {
            inputVector.y = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(-1, 0, 0));
        }
        if ()
        {
            inputVector.x = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, -1));
        }
        if ()
        {
            inputVector.y = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(1, 0, 0));
        }


        Vector3 moveDirection = new Vector3(inputVector.y, 0f, inputVector.x);
        bool canMove = !Physics.BoxCast(playerTransform.position, transform.localScale / 2, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Ground"));


        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f);
            canMove = moveDirection.x != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale / 2, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Ground"));

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z);
                canMove = moveDirection.z != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale / 2, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Ground"));

                if (canMove)
                {
                    moveDirection = moveDirectionZ;
                }
            }
        }



        if (canMove)
        {
            transform.position += moveDirection;
        }

    }
}
