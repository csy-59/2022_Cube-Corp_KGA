using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerInput input;
    private Rigidbody rigidBody;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        Vector3 deltaPosition = speed * Time.deltaTime * (Vector3.right * input.X + Vector3.forward * input.Z);
        Vector3 newPosition = transform.position + deltaPosition;

        rigidBody.MovePosition(newPosition);
    }
}
