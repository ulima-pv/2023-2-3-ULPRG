using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IdleState idleState;
    public FollowState followState;

    private State currentState;

    private void Awake() 
    {
        idleState = new IdleState(this);
        followState = new FollowState(this);

        currentState = idleState;    
    }

    private void Start() 
    {
        currentState.OnStart();
    }

    private void Update() 
    {
        currentState.OnUpdate();    
    }

}
