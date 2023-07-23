using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody rigidbody;
    private float moveSpeed = 1.6f;


    private void Update()
    {
        PlayerMovement();
    }


    public void PlayerMovement()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            inputVector.x = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, 1));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputVector.y = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputVector.x = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, -1));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputVector.y = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(1, 0, 0));
        }


        Vector3 moveDirection = new Vector3(inputVector.y, 0f, inputVector.x);
        bool canMove = !Physics.BoxCast(playerTransform.position, transform.localScale / 4, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Default"));


        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f);
            canMove = moveDirection.x != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale / 4, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Default"));

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z);
                canMove = moveDirection.z != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale / 4, moveDirection, Quaternion.identity, moveSpeed, LayerMask.GetMask("Default"));

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
