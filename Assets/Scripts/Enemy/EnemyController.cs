using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour
{
    public IdleState IdleState;
    public FollowState FollowState;

    public Transform Player;
    
    public Rigidbody rb {private set; get;}
    public float DistanceToFollow;
    public float Speed = 1f;

    private State currentState;

    private void Awake() 
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();

        // Seteamos el estado inicial
        currentState = IdleState;    
    }

    private void Start() 
    {
        currentState.OnStart();
    }

    private void Update() 
    {
        foreach (var transition in currentState.Transitions)
        {
            if (transition.IsValid())
            {
                // Ejecutar Transicion
                currentState.OnFinish();
                currentState = transition.GetNextState();
                currentState.OnStart();
                break;
            }
        }
        currentState.OnUpdate();    
    }

}
