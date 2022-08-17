using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;

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
        Vector3 deltaPosition = speed * Time.deltaTime * (rigidBody.transform.right * input.X + rigidBody.transform.forward * input.Z);
        Vector3 newPosition = transform.position + deltaPosition;

        rigidBody.MovePosition(newPosition);
    }
}
