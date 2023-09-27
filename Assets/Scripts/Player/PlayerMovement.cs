using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 Speed = new Vector2(-4f, 4f);

    private Rigidbody rb;
    private Vector2 moveDir;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        rb.velocity = new Vector3(
            moveDir.x * Speed.x,
            0f,
            moveDir.y * Speed.y
        );
    }

    private void OnMovement(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }

}
