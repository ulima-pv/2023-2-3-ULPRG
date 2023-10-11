using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public Func<bool> IsValid {private set; get;}
    public Func<State> GetNextState {private set; get;}

    public Transition(
        Func<bool> isValid,
        Func<State> getNextState
    ){
        IsValid = isValid;
        GetNextState = getNextState;
    }
}
