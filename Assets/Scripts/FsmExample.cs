﻿using Pattern_FSM.Scripts;
using UnityEngine;

public class FsmExample : MonoBehaviour

{
    private Fsm _fsm;
    private float _walkSpeed = 10f;
    private float _runSpeed = 20f;

    private void Start()
    {
        _fsm = new Fsm();

        _fsm.AddState(new FsmStateIdle(_fsm));
        _fsm.AddState(new FsmStateWalk(_fsm, transform, _walkSpeed));
        _fsm.AddState(new FsmStateRun(_fsm, transform, _runSpeed));

        _fsm.SetState<FsmStateIdle>(); // ставим состояние по умолчанию
            
    }

    private void Update()
    {
        _fsm.Update();
    }
}