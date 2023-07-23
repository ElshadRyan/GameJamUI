using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float timerMove;


    private float moveSpeed = 1.6f;
    private bool move;
    private int moveRight;
    private int moveForward;

    public int[] moveForwardSequence;
    public int[] moveRightSequence;
    private int i;

    private void Start()
    {
        i = -1;
        moveForward = 3;
        moveRight = 3;
    }

    void Update()
    {
        Timer();
    }

    public void MovementPath()
    {
        moveForward = moveForwardSequence[i];
        moveRight = moveRightSequence[i];
    }

    public void Timer()
    {
        if(timerMove > 0)
        {
            timerMove = timerMove - Time.deltaTime;
            move = false;
        }
        else
        {
            if (i < moveForwardSequence.Length - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            move = true;
            MovementPath();
            EnemyMove();
            timerMove = 2f;
        }        
    }

    public void EnemyMove()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (move && moveForward == 1)
        {
            inputVector.x = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, 1));
        }
        if (move && moveRight == 1)
        {
            inputVector.y = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(-1, 0, 0));
        }
        if (move && moveForward == 0)
        {
            inputVector.x = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, -1));
        }
        if (move && moveRight == 0)
        {
            inputVector.y = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(1, 0, 0));
        }


        Vector3 moveDirection = new Vector3(inputVector.y, 0f, inputVector.x);
        bool canMove = !Physics.BoxCast(playerTransform.position, transform.localScale / 2, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Default"));


        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f);
            canMove = moveDirection.x != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale / 2, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Default"));

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z);
                canMove = moveDirection.z != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale / 2, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Default"));

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
