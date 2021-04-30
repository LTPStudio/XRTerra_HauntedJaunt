using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator animator;
    Rigidbody rigidBody;
    Vector3 movement;
    Quaternion m_Rotation = Quaternion.identity;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {

        Vector2 inputVector = context.ReadValue<Vector2>();
        inputVector.Normalize();

        movement.Set(inputVector.x, 0, inputVector.y);
        bool isWalking = (movement.magnitude > .1f);

        animator.SetBool("IsWalking", isWalking);

        //bool isWalking 
    }

    void OnAnimatorMove()
    {
        rigidBody.MovePosition(rigidBody.position + movement * animator.deltaPosition.magnitude);
        // rigidBody.MoveRotation(m_Rotation);
        Vector3 desiredRotation = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);

        Quaternion rotation = Quaternion.LookRotation(desiredRotation);

        rigidBody.MoveRotation(rotation);
    }
}
